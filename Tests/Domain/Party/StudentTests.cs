using App.Aids;
using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Domain.Party;

[TestClass] public class StudentTests : SealedClassTests<Student, UniqueEntity<StudentData>> {
    protected override Student createObj() => new (GetRandom.Value<StudentData>());
    
    [TestMethod] public void FirstNameTest() => isReadOnly(obj.Data.FirstName);
    [TestMethod] public void LastNameTest() => isReadOnly(obj.Data.LastName);
    [TestMethod] public void PhoneNrTest() => isReadOnly(obj.Data.PhoneNr);
    [TestMethod] public void EmailTest() => isReadOnly(obj.Data.Email);
    [TestMethod] public void WeightTest() => isReadOnly(obj.Data.Weight);
    [TestMethod] public void HeightTest() => isReadOnly(obj.Data.Height);
    [TestMethod] public void ShoeSizeTest() => isReadOnly(obj.Data.ShoeSize);
    [TestMethod] public void EnrollmentDateTest() => isReadOnly(obj.Data.EnrollmentDate);
    [TestMethod] public void LevelTest() => isReadOnly(obj.Data.Level);
    [TestMethod] public void ToStringTest() {
        var expected = $"{obj.FirstName} {obj.LastName}";
        areEqual(expected, obj.ToString());
    }
}