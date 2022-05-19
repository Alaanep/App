using App.Aids;
using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using App.Facade.Party;
using App.Pages;
using App.Pages.Party;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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

        [DataRow("Not Known", Level.NotKnown)]
        [DataRow("B2", Level.B2)]
        [TestMethod]
        public void LevelDescriptionTest(string expected, Level level) {
            areEqual(expected, level.Description());

        }
        [TestMethod] public void GetValueTest() {
            var v = GetRandom.Value<StudentView>();
            v.FirstName = "Testest";
            areEqual("Testest", page?.GetValue("FirstName", v));
            areNotEqual("Testests", page?.GetValue("FirstName", v));
        }
        [TestMethod] public void LevelsTest() => isReadOnly<IEnumerable<SelectListItem>>();
    }
}

