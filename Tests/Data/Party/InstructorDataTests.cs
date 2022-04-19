using App.Data;
using App.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Data.Party
{
    [TestClass] public class InstructorDataTests:SealedClassTests<InstructorData, UniqueData> {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void PhoneNrTest() => isProperty<string?>();
        [TestMethod] public void LessonsGivenTest() => isProperty<string?>();

    }
}
