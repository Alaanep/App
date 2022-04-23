using System;
using App.Data.Party;
using App.Facade;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party {
    [TestClass]
    public class LessonViewTests: SealedClassTests<LessonView, UniqueView> {
        [TestMethod] public void InstructorTest() => isDisplayNamed<string>("Instructor");
        [TestMethod] public void StudentTest() => isDisplayNamed<string>("Student");
        [TestMethod] public void LessonNameTest() => isDisplayNamed<Level>("Lesson: ");
        [TestMethod] public void LessonTimeTest() => isDisplayNamed<DateTime>("Lesson Time");
        [TestMethod] public void LocationTest() => isDisplayNamed<string>("Location");
        [TestMethod] public void EquipmentNeededTest() => isDisplayNamed<string>("Equipment needed: ");
        [TestMethod] public void FullNameTest() => isDisplayNamed<string>("Lesson");
    }
}
