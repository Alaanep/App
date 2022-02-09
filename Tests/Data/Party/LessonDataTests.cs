using System;
using App.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Data.Party
{
    [TestClass]
    public class LessonDataTests: BaseTests<LessonData>
    {
        [TestMethod]public void IdTest() => isProperty<string>();
        [TestMethod] public void InstructorTest() => isProperty<string?>();
        [TestMethod] public void StudentTest() => isProperty<string?>();
        [TestMethod] public void LessonNameTest() => isProperty<string?>();
        [TestMethod] public void LessonTimeTest() => isProperty<DateTime?>();
        [TestMethod] public void LocationTest() => isProperty<string?>();
        [TestMethod] public void EquipmentNeededTest() => isProperty<string?>();
    }
}
