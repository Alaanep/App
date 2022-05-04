using App.Data.Party;
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
        protected override PagedRepo<Instructor, InstructorData> createObj() => new testClass(null, null);
    }
}

