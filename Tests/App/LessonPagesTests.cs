using App.Data.Party;
using App.Domain.Party;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace App.Tests.App {
    [TestClass]
    public class LessonPagesTests : PagesTests<ILessonsRepo, Lesson, LessonData, LessonView> {
        protected override string handlerName { get; set; } = "Lessons";
        protected override LessonData? data { get; set; }
        [TestInitialize]
        public void Initialize() {
            data = addRandomItems<ILessonsRepo, Lesson, LessonData>(out int cnt, x => new Lesson(x), id);
        }
        [TestMethod]public override async Task GetEditPageTest() {
            await base.GetEditPageTest();
            isNotNull(data);
            isNotNull(html);
            isTrue(html?.Contains(data?.LessonName.ToString()));
            isTrue(html?.Contains(data?.Location));
            isTrue(html?.Contains(data?.EquipmentNeeded));
            //isTrue(html.Contains(data.LessonTime.ToString()));
            isTrue(html?.Contains(data?.Instructor));
        }

        [TestMethod]public override async Task GetDetailsPageTest() {
            await base.GetDetailsPageTest();
            isNotNull(data);
            isNotNull(html);
            isTrue(html?.Contains(data?.LessonName.ToString()));
            isTrue(html?.Contains(data?.Location));
            isTrue(html?.Contains(data?.EquipmentNeeded));
            isTrue(html?.Contains(data?.LessonTime.ToString()));
            isTrue(html?.Contains(data?.Instructor));
            //isTrue(html.Contains(d.Student));
        }
        [TestMethod]public override async Task GetDeletePageTest() {
            await base.GetDeletePageTest();
            isNotNull(data);
            isNotNull(html);
            isTrue(html?.Contains(data?.LessonName.ToString()));
            isTrue(html?.Contains(data?.LessonTime.ToString()));
            isTrue(html?.Contains(data?.Instructor));
        }

        [TestMethod]
        public override async Task GetCreatePageTest() {
            await base.GetCreatePageTest();
            isNotNull(data);
            isNotNull(html);
            var a = nameof(Country.Description);
            isTrue(html?.Contains(nameof(Lesson.LessonName)));
            isTrue(html?.Contains(nameof(Lesson.Location)));
            isTrue(html?.Contains(nameof(Lesson.EquipmentNeeded)));
            isTrue(html?.Contains(nameof(Lesson.LessonTime)));
            isTrue(html?.Contains(nameof(Lesson.Student)));
            isTrue(html?.Contains(nameof(Lesson.Instructor)));
        }
    }
}
 
