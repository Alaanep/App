using App.Data.Party;
using App.Domain.Party;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party {
    [TestClass]public class InstructorViewFactoryTests: SealedClassTests<InstructorView> {
        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateViewTest() {
            var d = new InstructorData() {
                Id = "id",
                FirstName = "first",
                LastName = "last",
                PhoneNr = "phoneNr",
                LessonsGiven = "1"
            };
            var e = new Instructor(d);
            var v = new InstructorViewFactory().Create(e);
            isNotNull(v);
            areEqual(v.Id, e.Id);
            areEqual(v.FirstName, e.FirstName);
            areEqual(v.LastName, e.LastName);
            areEqual(v.PhoneNr, e.PhoneNr);
            areEqual(v.LessonsGiven, e.LessonsGiven);
            areEqual(v.FullName, e.ToString());
        }
        [TestMethod]
        public void CreateEntityTest() {
            var v = new InstructorView() {
                Id = "id",
                FirstName = "first",
                LastName = "last",
                PhoneNr = "PhoneNr",
                LessonsGiven = "1",
                FullName = "name"
            };
            var e = new InstructorViewFactory().Create(v);
            isNotNull(e);
            areEqual(e.Id, v.Id);
            areEqual(e.FirstName, v.FirstName);
            areEqual(e.LastName, v.LastName);
            areEqual(e.PhoneNr, v.PhoneNr);
            areEqual(e.LessonsGiven, v.LessonsGiven);
            areNotEqual(e.ToString(), v.FullName);
        }

    }
}
