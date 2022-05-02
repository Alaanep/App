using App.Data.Party;
using App.Domain.Party;
using App.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

