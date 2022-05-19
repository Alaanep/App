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
    public class LessonsPageTests : SealedBaseTests<LessonsPage, PagedPage<LessonView, Lesson, ILessonsRepo>> {
        private LessonsPage? page;
        protected override LessonsPage createObj() => page = new LessonsPage(GetRepo.Instance<ILessonsRepo>(), GetRepo.Instance<IStudentsRepo>());

        [TestMethod]
        public void IndexColumnsTest() {
            var arr = new string[] { "Instructor", "Student", "LessonName", "LessonTime", "Location", "EquipmentNeeded" };
            for (var i = 0; i < arr.Length; i++) {
                areEqual(arr[i], page?.IndexColumns[i]);
            }
        }
        [TestMethod] public void StudentNameTest() {
            var id = GetRandom.String();
            var data = addRandomItems<IStudentsRepo, Student, StudentData>(out int cnt, x => new Student(x), id);
            isNotNull(data);
            var expectedName = $"{data?.FirstName} {data?.LastName}";
            areEqual(expectedName, page?.StudentName(id));
            data = addRandomItems<IStudentsRepo, Student, StudentData>(out cnt, x => new Student(x));
            areEqual(expectedName, page?.StudentName(id));
            areNotEqual(GetRandom.String(), page?.StudentName(id));
        }
        [TestMethod] public void GetValueTest() {
            var v = GetRandom.Value<LessonView>();
            v.Location = "Testest";
            areEqual("Testest", page?.GetValue("Location", v));
            areNotEqual("Testests", page?.GetValue("Location", v));
        }
        [DataRow("Not Known", Level.NotKnown)]
        [DataRow("B2", Level.B2)]
        [TestMethod] public void LevelDescriptionTest(string expected, Level level) {
            areEqual(expected, level.Description());
            
        }
        [TestMethod] public void GetLessonValueTest() {
            var v = GetRandom.Value<LessonView>()?? new LessonView();
            v.LessonName = Level.B2;
            areEqual(Level.B2, page?.GetValue("LessonName", v));
            areNotEqual(Level.B3, page?.GetValue("LessonName", v));
        }
        [TestMethod] public void StudentsTest() => isReadOnly<IEnumerable<SelectListItem>>();
        [TestMethod] public void LevelsTest() => isReadOnly<IEnumerable<SelectListItem>>();
    }
}

