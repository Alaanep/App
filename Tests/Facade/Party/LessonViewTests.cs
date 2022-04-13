using System;
using App.Data.Party;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party {
    [TestClass]
    public class LessonViewTests: SealedClassTests<LessonView> {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void InstructorTest() => isProperty<string?>();
        [TestMethod] public void StudentTest() => isProperty<string?>();
        [TestMethod] public void LessonNameTest() => isProperty<Level>();
        [TestMethod] public void LessonTimeTest() => isProperty<DateTime?>();
        [TestMethod] public void LocationTest() => isProperty<string?>();
        [TestMethod] public void EquipmentNeededTest() => isProperty<string?>();
        [TestMethod] public void FullNameTest() => isProperty<string?>();
    }
}
