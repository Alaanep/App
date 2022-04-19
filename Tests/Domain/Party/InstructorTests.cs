using App.Aids;
using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Domain.Party;

[TestClass] public class InstructorTests : SealedClassTests<Instructor, UniqueEntity<InstructorData>> {
    protected override Instructor createObj() => new (GetRandom.Value<InstructorData>());

    [TestMethod] public void FirstNameTest() => isReadOnly(obj.Data.FirstName);
    [TestMethod] public void LastNameTest() => isReadOnly(obj.Data.LastName);
    [TestMethod] public void PhoneNrTest() => isReadOnly(obj.Data.PhoneNr);
    [TestMethod] public void LessonsGivenTest() => isReadOnly(obj.Data.LessonsGiven);
    [TestMethod] public void ToStringTest() => isInconclusive();
}