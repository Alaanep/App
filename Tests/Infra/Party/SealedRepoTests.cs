using App.Aids;
using App.Data;
using App.Domain;
using App.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace App.Tests.Infra.Party
{
    public abstract class SealedRepoTests<TClass, TBaseClass, TDomain, TData> :
        SealedBaseTests<TClass, TBaseClass>
        where TClass : FilteredRepo<TDomain, TData>
        where TBaseClass : class
        where TDomain : UniqueEntity<TData>, new()
        where TData : UniqueData, new()
    {
        private static Type dbType => typeof(AppDB);
        private static Type dbSetType => typeof(DbSet<TData>);
        private AppDB appDb{
            get{
                var o = obj.db;
                isNotNull(o);
                var db = o as AppDB;
                isNotNull(db);
                return db;
            }
        }

        protected void instanceTest(object? o, Type t){
            isNotNull(o);
            isInstanceOfType(o, t);
        }

        protected void instanceTest(object? o, Type t, object? expected)
        {
            instanceTest(o, t);
            instanceTest(expected, t);
            areEqual(expected, o);
        }
        [TestMethod] public void DbContextTest() => instanceTest(obj?.db, SealedRepoTests<TClass, TBaseClass, TDomain, TData>.dbType);
        [TestMethod] public void DbSet() => instanceTest(obj.set, SealedRepoTests<TClass, TBaseClass, TDomain, TData>.dbSetType, getSet(appDb));
        [TestMethod]public void ToDomainTest()
        {
            var d = GetRandom.Value<TData>();
            var o = obj.toDomain(d);
            isNotNull(o);
            isInstanceOfType(o, typeof(TDomain));
            areEqualProperties(d, o.Data);
        }
        protected abstract object? getSet(AppDB db);

        [TestMethod]
        public void AddFilterTest()
        {
            string contains(string s) => $"x.{s}.Contains";
            string toStrContains(string s) => $"x.{s}.ToString().Contains";
            obj.CurrentFilter = "abc";
            var q = obj.createSql();
            var s = q.Expression.ToString();
            isNotNull(q);
            foreach (var p in typeof(TData).GetProperties())
            {
                if (p.PropertyType == typeof(string))
                {
                    isTrue(s.Contains(contains(p.Name)), $"No Where found for property {p.Name}");
                }
                else
                {
                    isTrue(s.Contains(toStrContains(p.Name)), $"No Where found for property {p.Name}");
                }
            }
        }
    }
}
