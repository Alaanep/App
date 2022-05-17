using App.Data.Party;
using App.Domain.Party;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace App.Tests.App {
    [TestClass]
    public class StudentPagesTests : PagesTests<IStudentsRepo, Student, StudentData, StudentView> {
        protected override string handlerName { get; set; } = "Students";
        protected override StudentData? data { get; set; }
        [TestInitialize]
        public void Initialize() {
            data = addRandomItems<IStudentsRepo, Student, StudentData>(out int cnt, x => new Student(x), id);
        }

        [TestMethod]
        public override async Task GetEditPageTest() {
            await base.GetEditPageTest();
            isNotNull(data);
            isNotNull(html);
            isTrue(html.Contains(data.FirstName));
            isTrue(html.Contains(data.LastName));
            isTrue(html.Contains(data.Email));
            isTrue(html.Contains(data.ShoeSize));
            isTrue(html.Contains(data.Level.ToString()));
        }

        [TestMethod]
        public override async Task GetDetailsPageTest() {
            await base.GetDetailsPageTest();
            isNotNull(data);
            isNotNull(html);
            isTrue(html?.Contains(data?.FirstName));
            isTrue(html?.Contains(data?.LastName));
            isTrue(html?.Contains(data?.Email));
            isTrue(html?.Contains(data?.ShoeSize));
            isTrue(html?.Contains(data?.EnrollmentDate.ToString()));
            isTrue(html?.Contains(data?.Level.ToString()));
        }

        [TestMethod]
        public override async Task GetDeletePageTest() {
            await base.GetDeletePageTest();
            isNotNull(data);
            isNotNull(html);
            isTrue(html?.Contains(data?.FirstName));
            isTrue(html?.Contains(data?.LastName));
            isTrue(html?.Contains(data?.Level.ToString()));
        }

        [TestMethod]
        public override async Task GetCreatePageTest() {
            await base.GetCreatePageTest();
            isNotNull(data);
            isNotNull(html);
            var a = nameof(Country.Description);
            isTrue(html?.Contains(nameof(Student.FirstName)));
            isTrue(html?.Contains(nameof(Student.LastName)));
            isTrue(html?.Contains(nameof(Student.Email)));
            isTrue(html?.Contains(nameof(Student.Level)));
            isTrue(html?.Contains(nameof(Student.EnrollmentDate)));
            isTrue(html?.Contains(nameof(Student.ShoeSize)));
        }

    }
}
 
