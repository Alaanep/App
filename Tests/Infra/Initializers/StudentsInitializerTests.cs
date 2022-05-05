using App.Data.Party;
using App.Domain;
using App.Infra;
using App.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Infra.Initializers
{
    [TestClass] public class StudentsInitializerTests
        : SealedBaseTests<StudentsInitializer, BaseInitializer<StudentData>>
    {
        protected override StudentsInitializer createObj()
        {
            var db = GetRepo.Instance<AppDB>();
            return new StudentsInitializer(db);
        }
    }
}
