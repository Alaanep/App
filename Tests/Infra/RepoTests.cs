using App.Data.Party;
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
    public class RepoTests : AbstractClassTests<Repo<Instructor, InstructorData>, PagedRepo<Instructor, InstructorData>>
    {
        private class testClass : Repo<Instructor, InstructorData>
        {
            public testClass(DbContext? c, DbSet<InstructorData>? s) : base(c, s) { }

            protected internal override Instructor toDomain(InstructorData d) => new(d);
        }
        protected override Repo<Instructor, InstructorData> createObj() => new testClass(null, null);
    }

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

        [TestMethod] public void DbTest() => isInconclusive();
        [TestMethod] public void SetTest() => isInconclusive();
        [TestMethod] public void BaseRepoTest() => isInconclusive();
        [TestMethod] public void ClearTest() => isInconclusive();
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
    [TestClass]
    public class CrudRepoTests : AbstractClassTests<CrudRepo<Instructor, InstructorData>, BaseRepo<Instructor, InstructorData>>
    {
        private class testClass : CrudRepo<Instructor, InstructorData>
        {
            public testClass(DbContext? c, DbSet<InstructorData>? s) : base(c, s) { }
            protected  internal override Instructor toDomain(InstructorData d) => new(d);
        }
        protected override CrudRepo<Instructor, InstructorData> createObj() => new testClass(null, null);
    }

    [TestClass]
    public class FilteredRepoTests : AbstractClassTests<FilteredRepo<Instructor, InstructorData>, CrudRepo<Instructor, InstructorData>>
    {
        private class testClass : FilteredRepo<Instructor, InstructorData>
        {
            public testClass(DbContext? c, DbSet<InstructorData>? s) : base(c, s) { }
            protected internal override Instructor toDomain(InstructorData d) => new(d);
        }
        protected override FilteredRepo<Instructor, InstructorData> createObj() => new testClass(null, null);
    }

    [TestClass]
    public class OrdereredRepoTests : AbstractClassTests<OrderedRepo<Instructor, InstructorData>, FilteredRepo<Instructor, InstructorData>>
    {
        private class testClass : OrderedRepo<Instructor, InstructorData>
        {
            public testClass(DbContext? c, DbSet<InstructorData>? s) : base(c, s) { }
            protected internal override Instructor toDomain(InstructorData d) => new(d);
        }
        protected override OrderedRepo<Instructor, InstructorData> createObj() => new testClass(null, null);
    }

    [TestClass]
    public class PagedRepoTests : AbstractClassTests<PagedRepo<Instructor, InstructorData>, OrderedRepo<Instructor, InstructorData>>
    {
        private class testClass : PagedRepo<Instructor, InstructorData>
        {
            public testClass(DbContext? c, DbSet<InstructorData>? s) : base(c, s) { }
            protected internal override Instructor toDomain(InstructorData d) => new(d);
        }
        protected override PagedRepo<Instructor, InstructorData> createObj() => new testClass(null, null);
    }

    [TestClass]
    public class AppDBTests : SealedBaseTests<AppDB, DbContext>
    {
        protected override AppDB createObj() => null;
        protected override void isSealedTest() => isInconclusive();
    }
}

