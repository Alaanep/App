using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Facade;

namespace App.Tests.Facade.Party
{
    [TestClass]
    public class InstructorViewTests:SealedClassTests<InstructorView, UniqueView>
    {
        [TestMethod] public void FirstNameTest() => isDisplayNamed<string>("First name");
        [TestMethod] public void LastNameTest() => isDisplayNamed<string>("Last name");
        [TestMethod] public void PhoneNrTest() => isDisplayNamed<string>("Phone nr");
        [TestMethod] public void LessonsGivenTest() => isDisplayNamed<string>("Lessons given");
        [TestMethod] public void FullNameTest() => isDisplayNamed<string>("Full name");
    }
}
