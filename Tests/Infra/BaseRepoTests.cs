using App.Aids;
using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using App.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Tests.Infra
{
    [TestClass]
    public class BaseRepoTests : AbstractClassTests<BaseRepo<Instructor, InstructorData>, object>
    {
        private class testClass : BaseRepo<Instructor, InstructorData>
        {
            public testClass(DbContext? c, DbSet<InstructorData>? s) : base(c, s) { }
            public override bool Add(Instructor obj) => throw new NotImplementedException();
            public override Task<bool> AddAsync(Instructor obj) => throw new NotImplementedException();
            public override bool Delete(string id) => throw new NotImplementedException();
            public override Task<bool> DeleteAsync(string id) => throw new NotImplementedException();
            public override Instructor Get(string id) => throw new NotImplementedException();
            public override List<Instructor> Get() => throw new NotImplementedException();
            public override List<Instructor> GetAll(Func<Instructor, dynamic>? orderBy = null) => throw new NotImplementedException();
            public override Task<Instructor> GetAsync(string id) => throw new NotImplementedException();
            public override Task<List<Instructor>> GetAsync() => throw new NotImplementedException();
            public override bool Update(Instructor obj) => throw new NotImplementedException();
            public override Task<bool> UpdateAsync(Instructor obj) => throw new NotImplementedException();
        }
        protected override BaseRepo<Instructor, InstructorData> createObj() => new testClass(null, null);

        [TestMethod] public void dbTest() => isReadOnly<DbContext>();
        [TestMethod] public void setTest() => isReadOnly<DbSet<InstructorData>>();
        [TestMethod] public void BaseRepoTest()
        {
            var db = GetRepo.Instance<AppDB>();
            var set = db?.Instructors;
            isNotNull(set);
            obj = new testClass(db, set);
            areEqual(db, obj.db);
            areEqual(set, obj.set);
        }
        [TestMethod] public async Task ClearTest()
        {
            BaseRepoTest();
            var cnt = GetRandom.Int32(5, 30);
            var db = obj.db;
            isNotNull(db);
            var set = obj.set;
            isNotNull(set);
            for (var i = 0; i < cnt; i++) set.Add(GetRandom.Value<InstructorData>());
            db.SaveChanges();
            areEqual(cnt, await set.CountAsync());
            obj.clear();
            areEqual(0, await set.CountAsync());
        }
        [TestMethod] public void AddTest() => isAbstractMethod(nameof(obj.Add), typeof(Instructor));
        [TestMethod] public void GetTest() => isAbstractMethod(nameof(obj.Get), typeof(string));
        [TestMethod] public void GetListTest() => isAbstractMethod(nameof(obj.Get));
        [TestMethod] public void GetAllTest() => isAbstractMethod(nameof(obj.GetAll), typeof(Func<Instructor, dynamic>));
        [TestMethod] public void UpdateTest() => isAbstractMethod(nameof(obj.Update), typeof(Instructor));
        [TestMethod] public void DeleteTest() => isAbstractMethod(nameof(obj.Delete), typeof(string));
        [TestMethod] public void AddAsyncTest() => isAbstractMethod(nameof(obj.AddAsync), typeof(Instructor));
        [TestMethod] public void GetAsyncTest() => isAbstractMethod(nameof(obj.GetAsync), typeof(string));
        [TestMethod] public void GetAsyncListTest() => isAbstractMethod(nameof(obj.GetAsync));
        [TestMethod] public void UpdateAsyncTest() => isAbstractMethod(nameof(obj.UpdateAsync), typeof(Instructor));
        [TestMethod] public void DeleteAsyncTest() => isAbstractMethod(nameof(obj.DeleteAsync), typeof(string));
    }
}

