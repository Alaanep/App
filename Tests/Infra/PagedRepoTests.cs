using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using App.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Infra
{
    [TestClass]
    public class PagedRepoTests : AbstractClassTests<PagedRepo<Instructor, InstructorData>, OrderedRepo<Instructor, InstructorData>>
    {
        private class testClass : PagedRepo<Instructor, InstructorData>
        {
            public testClass(DbContext? c, DbSet<InstructorData>? s) : base(c, s) { }
            protected internal override Instructor toDomain(InstructorData d) => new(d);
        }
        protected override PagedRepo<Instructor, InstructorData> createObj() {
            var db = GetRepo.Instance<AppDB>();
            var set = db?.Instructors;
            isNotNull(set);
            return new testClass(db, set);
        } 

        [TestMethod] public void PageIndexTest() => isProperty<int>();
        [TestMethod] public void TotalPagesTest() => isReadOnly<int?>();
        [TestMethod] public void HasNextPageTest() => isReadOnly<bool>();
        [TestMethod] public void HasPreviousPageTest() => isReadOnly<bool>();
        [TestMethod] public void PageSizeTest() => isProperty<int>();
    }
}

