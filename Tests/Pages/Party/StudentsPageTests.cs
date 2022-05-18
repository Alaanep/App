using App.Domain;
using App.Domain.Party;
using App.Facade.Party;
using App.Pages;
using App.Pages.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Pages.Party {
    [TestClass]
    public class StudentsPageTests : SealedBaseTests<StudentsPage, PagedPage<StudentView, Student, IStudentsRepo>> {
        private StudentsPage? page;
        protected override StudentsPage createObj() => page =new StudentsPage(GetRepo.Instance<IStudentsRepo>());

        [TestMethod]
        public void IndexColumnsTest() {
            var arr = new string[] { "FirstName", "LastName", "PhoneNr", "Email", "Weight", "Height", "ShoeSize", "EnrollmentDate", "Level"};
            for (var i = 0; i < arr.Length; i++) {
                areEqual(arr[i], page?.IndexColumns[i]);
            }
        }

        [TestMethod] public void LevelDescriptionTest() => isInconclusive();
        [TestMethod] public void GetValueTest() => isInconclusive();
        [TestMethod] public void LevelsTest() => isInconclusive();
    }
}

