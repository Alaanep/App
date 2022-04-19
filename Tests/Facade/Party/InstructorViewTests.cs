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
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void  LastNameTest() => isProperty<string?>();
        [TestMethod] public void PhoneNrTest() => isProperty<string?>();
        [TestMethod] public void LessonsGivenTest() => isProperty<string?>();
        [TestMethod] public void FullNameTest() => isProperty<string?>();
    }
}
