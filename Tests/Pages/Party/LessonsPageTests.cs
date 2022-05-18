using App.Domain;
using App.Domain.Party;
using App.Facade.Party;
using App.Pages;
using App.Pages.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        [TestMethod] public void StudentNameTest() => isInconclusive();
        [TestMethod] public void GetValueTest() => isInconclusive();
        [TestMethod] public void LevelDescriptionTest() => isInconclusive();
        [TestMethod] public void GetLessonValueTest() => isInconclusive();
        [TestMethod] public void StudentsTest() => isInconclusive();
        [TestMethod] public void LevelsTest() => isInconclusive();
    }
}

