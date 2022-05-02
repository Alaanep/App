using App.Aids;
using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using App.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace App.Tests.Infra
{
    [TestClass]
    public class CrudRepoTests 
        : AbstractClassTests<CrudRepo<Instructor, InstructorData>, BaseRepo<Instructor, InstructorData>>
    {
        private AppDB? db;
        private DbSet<InstructorData>? set;
        private InstructorData? d;
        private Instructor? i;
        private int cnt;
        private class testClass : CrudRepo<Instructor, InstructorData>
        {
            public testClass(DbContext? c, DbSet<InstructorData>? s) : base(c, s) { }
            protected  internal override Instructor toDomain(InstructorData d) => new(d);
        }
        protected override CrudRepo<Instructor, InstructorData> createObj() {
            db = GetRepo.Instance<AppDB>();
            set = db?.Instructors;
            isNotNull(set);
            return new testClass(db, set);
        }
        [TestInitialize] public override void InitializeRepo() {
            base.InitializeRepo();
            initSet();
            initInstructor();
        }
        private void initSet() {
            cnt = GetRandom.Int32(5,15);
            for (var i = 0; i < cnt; i++) set?.Add(GetRandom.Value<InstructorData>());
            _ = db?.SaveChanges();
        }
        private void initInstructor() {
            d=GetRandom.Value<InstructorData>();
            isNotNull(d);
            i = new Instructor(d);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(x.Id, d.Id);
        }
        [TestMethod] public async Task AddTest() {
            isNotNull(i);
            isNotNull(set);
            _ = obj?.Add(i);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod] public async Task AddAsyncTest() {
            isNotNull(i);
            isNotNull(set);
            _ = await obj.AddAsync(i);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod] public async Task GetTest() {
            await AddTest();
            var x = obj.Get(d.Id);
            arePropertiesEqual(d, x.Data);
        }
        [TestMethod] public async Task GetAsyncTest() {
            await AddAsyncTest();
            var x = await obj.GetAsync(d.Id);
            arePropertiesEqual(d, x.Data);
        }
        [TestMethod] public void GetListTest() {
            var l= obj.Get();
            areEqual(cnt, l.Count);
        }
        [TestMethod] public async Task GetAsyncListTest() {
            var l = await obj.GetAsync();
            areEqual(cnt, l.Count);
        }
        [DataRow(nameof(Instructor.Id))]
        [DataRow(nameof(Instructor.FirstName))]
        [DataRow(nameof(Instructor.LastName))]
        [DataRow(nameof(Instructor.PhoneNr))]
        [DataRow(nameof(Instructor.LessonsGiven))]
        [DataRow(nameof(Instructor.ToString))]
        [TestMethod] public void GetAllTest(string s) {
            Func<Instructor, dynamic>? orderBy = null;
            if (s is nameof(Instructor.Id)) orderBy = x => x.Id;
            else if (s is nameof(Instructor.FirstName)) orderBy = x => x.FirstName;
            else if (s is nameof(Instructor.LastName)) orderBy = x => x.LastName;
            else if (s is nameof(Instructor.PhoneNr)) orderBy = x => x.PhoneNr;
            else if (s is nameof(Instructor.LessonsGiven)) orderBy = x => x.LessonsGiven;
            else if (s is nameof(Instructor.ToString)) orderBy = x => x.ToString();
            var l = obj.GetAll(orderBy);
            areEqual(cnt, l.Count);
            if (orderBy is null) return;
            for (var i = 0; i < l.Count - 1; i++) { 
                var a = l[i];
                var b = l[i + 1];
                var aX = orderBy(a) as IComparable;
                var bX = orderBy(b) as IComparable;
                isNotNull(aX);
                isNotNull(bX);
                var r = aX.CompareTo(bX);
                isTrue(r <= 0);
            }
        }
        [TestMethod] public async Task UpdateTest() {
            await GetTest();
            var dX = GetRandom.Value<InstructorData>() as InstructorData;
            isNotNull(d);
            isNotNull(dX);
            dX.Id = d.Id;
            var iX = new Instructor(dX);
            obj.Update(iX);
            var x = obj.Get(d.Id);
            areEqualProperties(dX, x.Data);
        }
        [TestMethod] public async Task UpdateAsyncTest() {
            await GetTest();
            var dX = GetRandom.Value<InstructorData>() as InstructorData;
            isNotNull(d);
            isNotNull(dX);
            dX.Id = d.Id;
            var iX = new Instructor(dX);
            await obj.UpdateAsync(iX);
            var x = obj.Get(d.Id);
            areEqualProperties(dX, x.Data);
        }
        [TestMethod] public async Task DeleteTest() {
            isNotNull(d);
            await GetTest();
            obj.Delete(d.Id);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(x.Id, d.Id);
        }
        [TestMethod] public async Task DeleteAsyncTest() {
            isNotNull(d);
            await GetTest();
            _ = await obj.DeleteAsync(d.Id);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(x.Id, d.Id);
        }
    }
}

