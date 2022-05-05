using App.Data.Party;
using App.Domain;
using App.Infra;
using App.Infra.Initializers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace App.Tests.Infra.Initializers
{
    [TestClass] public class BaseInitializerTests
        : AbstractClassTests<BaseInitializer<InstructorData>, object> {

        private class testClass : BaseInitializer<InstructorData>
        {
            public testClass(DbContext? c, DbSet<InstructorData>? s) : base (c, s) { }
            protected override IEnumerable<InstructorData> getEntities => throw new System.NotImplementedException();
        }
        protected override BaseInitializer<InstructorData> createObj()
        {
            var db = GetRepo.Instance<AppDB>();
            var set = db?.Instructors;
            return new testClass(db, set);
        }

        [TestMethod] public void InitTest() => isInconclusive();
    }
}
