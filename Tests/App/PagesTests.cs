using App.Aids;
using App.Data;
using App.Domain;
using App.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace App.Tests.App {

    public abstract class PagesTests<TRepo, TObj, TData, TView> : HostTests
        where TRepo : class, IRepo<TObj>
        where TObj : UniqueEntity<TData>, new()
        where TView : UniqueView, new()
        where TData : UniqueData, new() {

        protected abstract string handlerName { get; set; }
        protected string? id { get; set; }
        protected abstract TData? data { get; set; }
        protected string? html { get; set; }

        [TestInitialize]public void InitPagesTests() {
            id = GetRandom.String();
            //data = addRandomItems<TRepo, TObj, TData>(out cnt, x => new TObj(x), id);
        }

        [TestMethod]
        public async Task GetIndexPageTest() {
            var page = await client.GetAsync($"/{handlerName}?handler=Index");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Index</h1>"));
            isTrue(html.Contains($"<h4>{handlerName}</h4>"));
        }

        [TestMethod]
        public virtual async Task GetEditPageTest() {
            var page = await client.GetAsync($"/{handlerName}/Edit?handler=Edit&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Edit</h1>"));
            isTrue(html.Contains($"<h4>{handlerName}</h4>"));
            isTrue(html.Contains($"<input class=\"form-control text-box single-line\""));
            isTrue(html.Contains("<input type=\"submit\" value=\"Save\" class=\"btn btn-primary\" />"));
            isTrue(html.Contains($"<a href=\"/{handlerName}?idx=0&amp;handler=Index\">Back to List</a>"));
        }

        [TestMethod]
        public virtual async Task GetDetailsPageTest() {
            var page = await client.GetAsync($"/{handlerName}/Details?handler=Details&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Details</h1>"));
            isTrue(html.Contains($"<h4>{handlerName}</h4>"));
        }

        [TestMethod]
        public virtual async Task GetDeletePageTest() {
            var page = await client.GetAsync($"/{handlerName}/Delete?handler=Delete&id={id}&order=&idx=0&filter=");
            areEqual(HttpStatusCode.OK, page.StatusCode);
            html = await page.Content.ReadAsStringAsync();
            isTrue(html.Contains("<h1>Delete</h1>"));
            isTrue(html.Contains($"<h4>{handlerName}</h4>"));
            isTrue(html.Contains("<input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" />"));
            isTrue(html.Contains($"<a href=\"/{handlerName}?idx=0&amp;handler=Index\">Back to List</a>"));
        }

        [TestMethod] public virtual async Task GetCreatePageTest() {
            var page = await client.GetAsync($"/{handlerName}/Create?idx=0&handler=Create");
            html = await page.Content.ReadAsStringAsync();
            areEqual(HttpStatusCode.OK, page.StatusCode);
            isTrue(html.Contains("<h1>Create</h1>"));
            isTrue(html.Contains($"<h4>{handlerName}</h4>"));
            isTrue(html.Contains($"<form method=\"post\" action=\"/{handlerName}/Create?idx=0&amp;handler=Create\">"));
        }

        [TestMethod] public async Task PostEditPageTest() {
            //isNotNull(data);
            //StringContent queryString = new StringContent(data.ToString());
            //var page = await client.PostAsync($"/{handlerName}/Edit?idx=0&handler=Edit", queryString);
            //isNotNull(page);
            isInconclusive();
        }

        [TestMethod] public async Task PostDeletePageTest() => isInconclusive();
    }
}
 
