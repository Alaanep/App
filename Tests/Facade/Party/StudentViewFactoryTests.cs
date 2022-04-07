using App.Aids;
using App.Data.Party;
using App.Domain.Party;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party {
    [TestClass]public class StudentViewFactoryTests: SealedClassTests<StudentView> {

        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateViewTest() {
            var d = GetRandom.Value<StudentData>();
            var e = new Student(d);
            var v = new StudentViewFactory().Create(e);
            isNotNull(v);
            areEqual(v.Id, e.Id);
            areEqual(v.FirstName, e.FirstName);
            areEqual(v.LastName, e.LastName);
            areEqual(v.PhoneNr, e.PhoneNr);
            areEqual(v.Email, e.Email);
            areEqual(v.Weight, e.Weight);
            areEqual(v.Height, e.Height);
            areEqual(v.ShoeSize, e.ShoeSize);
            areEqual(v.EnrollmentDate, e.EnrollmentDate);
            areEqual(v.Level, e.Level);
            areEqual(v.FullName, e.ToString());
        }
        [TestMethod]
        public void CreateEntityTest() {
            var v = GetRandom.Value<StudentView>();
            var e = new StudentViewFactory().Create(v);
            isNotNull(e);
            areEqual(e.Id, v?.Id);
            areEqual(e.FirstName, v?.FirstName);
            areEqual(e.LastName, v?.LastName);
            areEqual(e.PhoneNr, v?.PhoneNr);
            areEqual(e.Email, v?.Email);
            areEqual(e.Weight, v?.Weight);
            areEqual(e.Height, v?.Height);
            areEqual(e.ShoeSize, v?.ShoeSize);
            areEqual(e.EnrollmentDate, v?.EnrollmentDate);
            areEqual(e.Level, v?.Level);
            areNotEqual(e.ToString(), v?.FullName);
        }
    }
}
