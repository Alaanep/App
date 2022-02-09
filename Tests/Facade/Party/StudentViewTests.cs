﻿using System;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party
{
    [TestClass]
    public class StudentViewTests: BaseTests<StudentView>
    {

        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void PhoneNrTest() => isProperty<string?>();
        [TestMethod] public void EmailTest() => isProperty<string?>();
        [TestMethod] public void WeightTest() => isProperty<string?>();
        [TestMethod] public void HeightTest() => isProperty<string?>();
        [TestMethod] public void ShoeSizeTest() => isProperty<string?>();
        [TestMethod] public void EnrollmentDateTest() => isProperty<DateTime?>();
        [TestMethod] public void LevelTest() => isProperty<string?>();
        [TestMethod] public void FullNameTest() => isProperty<string?>();
    }
}
