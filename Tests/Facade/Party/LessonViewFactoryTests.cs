using App.Aids;
using App.Data.Party;
using App.Domain.Party;
using App.Facade;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party {
    [TestClass]public class LessonViewFactoryTests
        : SealedClassTests<LessonViewFactory, BaseViewFactory<LessonView, Lesson, LessonData>> {

        [TestMethod] public void CreateTest() { }

        [TestMethod]
        public void CreateViewTest() {
        var d = GetRandom.Value<LessonData>();
            var e = new Lesson(d);
            var v = new LessonViewFactory().Create(e);
            isNotNull(v);
            areEqual(v.Id, e.Id);
            areEqual(v.Instructor, e.Instructor);
            areEqual(v.Student, e.Student);
            areEqual(v.LessonName, e.LessonName);
            areEqual(v.LessonTime, e.LessonTime);
            areEqual(v.Location, e.Location);
            areEqual(v.EquipmentNeeded, e.EquipmentNeeded);
            areEqual(v.FullName, e.ToString());
        }
        [TestMethod]
        public void CreateEntityTest() {
            var v = GetRandom.Value<LessonView>();
            var e = new LessonViewFactory().Create(v);
            isNotNull(e);
            areEqual(e.Id, v?.Id);
            areEqual(e.Instructor, v?.Instructor);
            areEqual(e.Student, v?.Student);
            areEqual(e.LessonName, v?.LessonName);
            areEqual(e.LessonTime, v?.LessonTime);
            areEqual(e.Location, v?.Location);
            areEqual(e.EquipmentNeeded, v?.EquipmentNeeded);
            areNotEqual(e.ToString(), v?.FullName);
        }
    }
}
