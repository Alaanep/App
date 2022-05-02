using App.Data.Party;
using App.Domain;
using App.Infra;
using App.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Infra.Initializers
{
    [TestClass] public class InstructorsInitializerTest 
        : SealedBaseTests<InstructorsInitializer, BaseInitializer<InstructorData>> {
        protected override InstructorsInitializer createObj()
        {
            var db = GetRepo.Instance<AppDB>();
            return new InstructorsInitializer(db);
        }
    }
}
