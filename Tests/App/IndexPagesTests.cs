using App.Aids;
using App.Data.Party;
using App.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Threading.Tasks;

namespace App.Tests.App {

    [TestClass] public class IndexPagesTests : HostTests {
        
        //get index tests
        [TestMethod] public async Task GetCountriesIndexPageTest() {
            int cnt;
            var d = addRandomItems<ICountriesRepo, Country, CountryData>(out cnt, x => new Country(x));
            var page = await client.GetAsync("/Countries?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Index</h1>"));
            isTrue(html.Contains("<h4>Countries</h4>"));
        }

        [TestMethod]
        public async Task GetCurrenciesIndexPageTest() {
            int cnt;
            var d = addRandomItems<ICurrenciesRepo, Currency, CurrencyData>(out cnt, x => new Currency(x));
            var page = await client.GetAsync("/Currencies?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Index</h1>"));
            isTrue(html.Contains("<h4>Currencies</h4>"));
        }

        [TestMethod]
        public async Task GetCountryCurrenciesIndexPageTest() {
            int cnt;
            var d = addRandomItems<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(out cnt, x => new CountryCurrency(x));
            var page = await client.GetAsync("/CountryCurrencies?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Index</h1>"));
            isTrue(html.Contains("<h4>CountryCurrencies</h4>"));
        }

        [TestMethod]
        public async Task GetStudentsIndexPageTest() {
            int cnt;
            var d = addRandomItems<IStudentsRepo, Student, StudentData>(out cnt, x => new Student(x));
            var page = await client.GetAsync("/Students?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Index</h1>"));
            isTrue(html.Contains("<h4>Students</h4>"));
        }
        [TestMethod]
        public async Task GetLessonsIndexPageTest() {
            int cnt;
            var d = addRandomItems<ILessonsRepo, Lesson, LessonData>(out cnt, x => new Lesson(x));
            var page = await client.GetAsync("/Lessons?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Index</h1>"));
            isTrue(html.Contains("<h4>Lessons</h4>"));
        }

        [TestMethod]
        public async Task GetInstructorsIndexPageTest() {
            int cnt;
            var d = addRandomItems<IInstructorsRepo, Instructor, InstructorData>(out cnt, x => new Instructor(x));
            var page = await client.GetAsync("/Instructors?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Index</h1>"));
            isTrue(html.Contains("<h4>Instructors</h4>"));
        }


        //get edit tests
        [TestMethod]
        public async Task GetCountriesEditPageTest() {
            int cnt;
            var id = GetRandom.String();
            var d = addRandomItems<ICountriesRepo, Country, CountryData>(out cnt, x => new Country(x), id);
            isNotNull(d);
            isNotNull(d.Description);
            isNotNull(d.Name);
            isNotNull(d.Code);
            var page = await client.GetAsync($"/Countries/Edit?handler=Edit&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Edit</h1>"));
            isTrue(html.Contains(id));
            isTrue(html.Contains($"<input class=\"form-control text-box single-line\""));
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Description));
            isTrue(html.Contains(d.Name));
            isTrue(html.Contains("<input type=\"submit\" value=\"Save\" class=\"btn btn-primary\" />"));
            isTrue(html.Contains("<a href=\"/Countries?idx=0&amp;handler=Index\">Back to List</a>"));
        }

        [TestMethod]
        public async Task GetCurrenciesEditPageTest() {
            int cnt;
            var id = GetRandom.String();
            var d = addRandomItems<ICurrenciesRepo, Currency, CurrencyData>(out cnt, x => new Currency(x), id);
            isNotNull(d);
            isNotNull(d.Description);
            isNotNull(d.Name);
            isNotNull(d.Code);
            var page = await client.GetAsync($"/Currencies/Edit?handler=Edit&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Edit</h1>"));
            isTrue(html.Contains(id));
            isTrue(html.Contains($"<input class=\"form-control text-box single-line\""));
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Description));
            isTrue(html.Contains(d.Name));
            isTrue(html.Contains("<input type=\"submit\" value=\"Save\" class=\"btn btn-primary\" />"));
            isTrue(html.Contains("<a href=\"/Currencies?idx=0&amp;handler=Index\">Back to List</a>"));
        }

        [TestMethod]
        public async Task GetCountryCurrenciesEditPageTest() {
            int cnt;
            var id = GetRandom.String();
            var d = addRandomItems<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(out cnt, x => new CountryCurrency(x), id);
            isNotNull(d);
            //isNotNull(d.Description);
            isNotNull(d.Name);
            isNotNull(d.Code);
            var page = await client.GetAsync($"/CountryCurrencies/Edit?handler=Edit&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Edit</h1>"));
            isTrue(html.Contains(id));
            isTrue(html.Contains($"<input class=\"form-control text-box single-line\""));
            isTrue(html.Contains(d.Code));
            //isTrue(html.Contains(d.Description));
            isTrue(html.Contains(d.Name));
            isTrue(html.Contains("<input type=\"submit\" value=\"Save\" class=\"btn btn-primary\" />"));
            isTrue(html.Contains("<a href=\"/CountryCurrencies?idx=0&amp;handler=Index\">Back to List</a>"));
        }

        [TestMethod]
        public async Task GetStudentsEditPageTest() {
            int cnt;
            var id = GetRandom.String();
            var d = addRandomItems<IStudentsRepo, Student, StudentData>(out cnt, x => new Student(x), id);
            isNotNull(d);
            isNotNull(d.FirstName);
            isNotNull(d.LastName);
            isNotNull(d.Email);
            isNotNull(d.ShoeSize);
            isNotNull(d.EnrollmentDate);
            isNotNull(d.Level);
            var page = await client.GetAsync($"/Students/Edit?handler=Edit&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Edit</h1>"));
            isTrue(html.Contains(id));
            isTrue(html.Contains($"<input class=\"form-control text-box single-line\""));
            isTrue(html.Contains(d.FirstName));
            isTrue(html.Contains(d.LastName));
            isTrue(html.Contains(d.Email));
            isTrue(html.Contains(d.ShoeSize));
            //isTrue(html.Contains(d.EnrollmentDate.ToString()));
            isTrue(html.Contains(d.Level.ToString()));
            isTrue(html.Contains("<input type=\"submit\" value=\"Save\" class=\"btn btn-primary\" />"));
            isTrue(html.Contains("<a href=\"/Students?idx=0&amp;handler=Index\">Back to List</a>"));
        }

        [TestMethod]
        public async Task GetLessonsEditPageTest() {
            int cnt;
            var id = GetRandom.String();
            var d = addRandomItems<ILessonsRepo, Lesson, LessonData>(out cnt, x => new Lesson(x), id);
            isNotNull(d.LessonName);
            isNotNull(d.Location);
            isNotNull(d.EquipmentNeeded);
            isNotNull(d.LessonTime);
            isNotNull(d.Instructor);
            isNotNull(d.Student);
            var page = await client.GetAsync($"/Lessons/Edit?handler=Edit&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Edit</h1>"));
            isTrue(html.Contains(id));
            isTrue(html.Contains(d.LessonName.ToString()));
            isTrue(html.Contains(d.Location));
            isTrue(html.Contains(d.EquipmentNeeded));
            //isTrue(html.Contains(d.LessonTime.ToString()));
            isTrue(html.Contains(d.Instructor));
            isTrue(html.Contains("<input type=\"submit\" value=\"Save\" class=\"btn btn-primary\" />"));
            isTrue(html.Contains("<a href=\"/Lessons?idx=0&amp;handler=Index\">Back to List</a>"));
        }

        [TestMethod]
        public async Task GetInstructorsEditPageTest() {
            int cnt;
            var id = GetRandom.String();
            var d = addRandomItems<IInstructorsRepo, Instructor, InstructorData>(out cnt, x => new Instructor(x), id);
            isNotNull(d);
            isNotNull(d.FirstName);
            isNotNull(d.LastName);
            isNotNull(d.PhoneNr);
            isNotNull(d.LessonsGiven);
            var page = await client.GetAsync($"/Instructors/Edit?handler=Edit&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Edit</h1>"));
            isTrue(html.Contains(id));
            isTrue(html.Contains(d.FirstName));
            isTrue(html.Contains(d.LastName));
            isTrue(html.Contains(d.PhoneNr));
            isTrue(html.Contains(d.LessonsGiven));
            isTrue(html.Contains("<input type=\"submit\" value=\"Save\" class=\"btn btn-primary\" />"));
            isTrue(html.Contains("<a href=\"/Instructors?idx=0&amp;handler=Index\">Back to List</a>"));
        }

        // get details tests

        [TestMethod] public async Task GetCountriesDetailsPageTest() {
            int cnt;
            var id = GetRandom.String();
            var d = addRandomItems<ICountriesRepo, Country, CountryData>(out cnt, x => new Country(x), id);
            isNotNull(d);
            isNotNull(d.Description);
            isNotNull(d.Name);
            isNotNull(d.Code);
            var page = await client.GetAsync($"/Countries/Details?handler=Details&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Details</h1>"));
            isTrue(html.Contains(id));
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Description));
            isTrue(html.Contains(d.Name));
        }

        [TestMethod]
        public async Task GetCurrenciesDetailsPageTest() {
            int cnt;
            var id = GetRandom.String();
            var d = addRandomItems<ICurrenciesRepo, Currency, CurrencyData>(out cnt, x => new Currency(x), id);
            isNotNull(d);
            isNotNull(d.Description);
            isNotNull(d.Name);
            isNotNull(d.Code);
            var page = await client.GetAsync($"/Currencies/Details?handler=Details&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Details</h1>"));
            isTrue(html.Contains(id));
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Description));
            isTrue(html.Contains(d.Name));
        }

        [TestMethod]
        public async Task GetCountryCurrenciesDetailsPageTest() {
            int cnt;
            var id = GetRandom.String();
            var d = addRandomItems<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(out cnt, x => new CountryCurrency(x), id);
            isNotNull(d);
            isNotNull(d.Description);
            isNotNull(d.Name);
            isNotNull(d.Code);
            var page = await client.GetAsync($"/CountryCurrencies/Details?handler=Details&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Details</h1>"));
            isTrue(html.Contains(id));
            isTrue(html.Contains(d.Code));
        }

        [TestMethod]
        public async Task GetStudentsDetailsPageTest() {
            int cnt;
            var id = GetRandom.String();
            var d = addRandomItems<IStudentsRepo, Student, StudentData>(out cnt, x => new Student(x), id);
            isNotNull(d);
            isNotNull(d.FirstName);
            isNotNull(d.LastName);
            isNotNull(d.Email);
            isNotNull(d.ShoeSize);
            isNotNull(d.EnrollmentDate);
            isNotNull(d.Level);
            var page = await client.GetAsync($"/Students/Details?handler=Details&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Details</h1>"));
            isTrue(html.Contains(id));
            isTrue(html.Contains(d.FirstName));
            isTrue(html.Contains(d.LastName));
            isTrue(html.Contains(d.Email));
            isTrue(html.Contains(d.ShoeSize));
            isTrue(html.Contains(d.EnrollmentDate.ToString()));
            isTrue(html.Contains(d.Level.ToString()));
        }

        [TestMethod]
        public async Task GetLessonsDetailsPageTest() {
            int cnt;
            var id = GetRandom.String();
            var d = addRandomItems<ILessonsRepo, Lesson, LessonData>(out cnt, x => new Lesson(x), id);
            isNotNull(d);
            isNotNull(d.LessonName);
            isNotNull(d.Location);
            isNotNull(d.EquipmentNeeded);
            isNotNull(d.LessonTime);
            isNotNull(d.Instructor);
            isNotNull(d.Student);
            var page = await client.GetAsync($"/Lessons/Details?handler=Details&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Details</h1>"));
            isTrue(html.Contains(id));
            isTrue(html.Contains(d.LessonName.ToString()));
            isTrue(html.Contains(d.Location));
            isTrue(html.Contains(d.EquipmentNeeded));
            isTrue(html.Contains(d.LessonTime.ToString()));
            isTrue(html.Contains(d.Instructor));
            //isTrue(html.Contains(d.Student));
        }

        [TestMethod]
        public async Task GetInstructorsDetailsPageTest() {
            int cnt;
            var id = GetRandom.String();
            var d = addRandomItems<IInstructorsRepo, Instructor, InstructorData>(out cnt, x => new Instructor(x), id);
            isNotNull(d);
            isNotNull(d.FirstName);
            isNotNull(d.LastName);
            isNotNull(d.PhoneNr);
            isNotNull(d.LessonsGiven);
            
            var page = await client.GetAsync($"/Instructors/Details?handler=Details&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Details</h1>"));
            isTrue(html.Contains(id));
            isTrue(html.Contains(d.FirstName));
            isTrue(html.Contains(d.LastName));
            isTrue(html.Contains(d.PhoneNr));
            isTrue(html.Contains(d.LessonsGiven));
            //isTrue(html.Contains(d.Student));
        }

        //get delete tests
        [TestMethod]
        public async Task GetCountriesDeletePageTest() {
            int cnt;
            var id = GetRandom.String();
            var d = addRandomItems<ICountriesRepo, Country, CountryData>(out cnt, x => new Country(x), id);
            isNotNull(d);
            isNotNull(d.Description);
            isNotNull(d.Name);
            isNotNull(d.Code);
            var page = await client.GetAsync($"/Countries/Delete?handler=Delete&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            var html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Delete</h1>"));
            isTrue(html.Contains(id));
            isTrue(html.Contains($"<input class=\"form-control text-box single-line\""));
            isTrue(html.Contains(d.Code));
            isTrue(html.Contains(d.Description));
            isTrue(html.Contains(d.Name));
            isTrue(html.Contains("<input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" />"));
            isTrue(html.Contains("<a href=\"/Countries?idx=0&amp;handler=Index\">Back to List</a>"));
        }

    }
}
