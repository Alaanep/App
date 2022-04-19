using App.Aids;
using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Domain.Party;

[TestClass] public class LessonTests : SealedClassTests<Lesson, UniqueEntity<LessonData>> {
    protected override Lesson createObj() => new (GetRandom.Value<LessonData>());
    [TestMethod] public void InstructorTest() => isReadOnly(obj.Data.Instructor);
    [TestMethod] public void StudentTest() => isReadOnly(obj.Data.Student);
    [TestMethod] public void LessonNameTest() => isReadOnly(obj.Data.LessonName);
    [TestMethod] public void LessonTimeTest() => isReadOnly(obj.Data.LessonTime);
    [TestMethod] public void LocationTest() => isReadOnly(obj.Data.Location);
    [TestMethod] public void EquipmentNeededTest() => isReadOnly(obj.Data.EquipmentNeeded);
    [TestMethod] public void ToStringTest() => isInconclusive();
}