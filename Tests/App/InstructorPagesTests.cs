using App.Data.Party;
using App.Domain.Party;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace App.Tests.App {
    [TestClass]
    public class InstructorPagesTests : PagesTests<IInstructorsRepo, Instructor, InstructorData, InstructorView> {
        protected override string? handlerName { get; set; } = "Instructors";
        protected override InstructorData? data { get; set; }
        [TestInitialize]
        public void Initialize() {
            data = addRandomItems<IInstructorsRepo, Instructor, InstructorData>(out int cnt, x => new Instructor(x), id);
        }
        [TestMethod]public override async Task GetEditPageTest() {
            await base.GetEditPageTest();
            isNotNull(data);
            isNotNull(html);
            isTrue(html?.Contains(data?.FirstName));
            isTrue(html?.Contains(data?.LastName));
            isTrue(html?.Contains(data?.PhoneNr));
            isTrue(html?.Contains(data?.LessonsGiven));
        }
        [TestMethod]public override async Task GetDetailsPageTest() {
            await base.GetDetailsPageTest();
            isNotNull(data);
            isNotNull(html);
            isTrue(html?.Contains(data?.FirstName));
            isTrue(html?.Contains(data?.LastName));
            isTrue(html?.Contains(data?.PhoneNr));
            isTrue(html?.Contains(data?.LessonsGiven));
            //isTrue(html.Contains(d.Student));
        }
        [TestMethod]public override async Task GetDeletePageTest() {
            await base.GetDeletePageTest();
            isNotNull(data);
            isNotNull(html);
            isTrue(html?.Contains(data?.FirstName));
            isTrue(html?.Contains(data?.LastName));
        }

        [TestMethod]public override async Task GetCreatePageTest() {
            await base.GetCreatePageTest();
            isNotNull(data);
            isNotNull(html);
            var a = nameof(Country.Description);
            isTrue(html?.Contains(nameof(Instructor.FirstName)));
            isTrue(html?.Contains(nameof(Instructor.LastName)));
            isTrue(html?.Contains(nameof(Instructor.LessonsGiven)));
            isTrue(html?.Contains(nameof(Instructor.PhoneNr)));
        }
    }
}
 
