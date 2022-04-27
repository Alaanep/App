using System;
using App.Data.Party;
using App.Facade;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party{
    [TestClass]
    public class StudentViewTests: SealedClassTests<StudentView, UniqueView>{
        [TestMethod] public void FirstNameTest() => isDisplayNamed<string>("First Name");
        [TestMethod] public void LastNameTest() => isDisplayNamed<string>("Last Name");
        [TestMethod] public void PhoneNrTest() => isDisplayNamed<string>("Phone nr");
        [TestMethod] public void EmailTest() => isDisplayNamed<string>("Email");
        [TestMethod] public void WeightTest() => isDisplayNamed<string>("Weight");
        [TestMethod] public void HeightTest() => isDisplayNamed<string>("Height");
        [TestMethod] public void ShoeSizeTest() => isDisplayNamed<string>("Shoe Size");
        [TestMethod] public void EnrollmentDateTest() => isDisplayNamed<DateTime>("Enrollment Date");
        [TestMethod] public void LevelTest() => isDisplayNamed<Level>("Level");
        [TestMethod] public void FullNameTest() => isDisplayNamed<string>("Full Name");
    }
}
