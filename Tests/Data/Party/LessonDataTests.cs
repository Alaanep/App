using System;
using App.Data;
using App.Data.Party;
using App.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Data.Party
{
    [TestClass]
    public class LessonDataTests: SealedClassTests<LessonData, UniqueData>
    {
        [TestMethod]public void IdTest() => isProperty<string>();
        [TestMethod] public void InstructorTest() => isProperty<string?>();
        [TestMethod] public void StudentTest() => isProperty<string?>();
        [TestMethod] public void LessonNameTest() => isProperty<Level>();
        [TestMethod] public void LessonTimeTest() => isProperty<DateTime?>();
        [TestMethod] public void LocationTest() => isProperty<string?>();
        [TestMethod] public void EquipmentNeededTest() => isProperty<string?>();
    }
}
