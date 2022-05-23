using App.Aids;
using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using App.Facade.Party;
using App.Infra;
using App.Infra.Party;
using App.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Tests.Pages {
    [TestClass] public class BasePageTests : AbstractClassTests<BasePage<CountryView, Country, ICountriesRepo>, PageModel> {


        private class testClass : BasePage<CountryView, Country, ICountriesRepo> {
            public testClass(ICountriesRepo r) : base(r) { }
            protected override IActionResult getCreate() => null;
            protected override Task<IActionResult> getDeleteAsync(string id) => throw new NotImplementedException();
            protected override Task<IActionResult> getDetailsAsync(string id) => throw new NotImplementedException();
            protected override Task<IActionResult> getEditAsync(string id) => throw new NotImplementedException();
            protected override Task<IActionResult> getIndexAsync() => throw new NotImplementedException();
            protected override Task<IActionResult> postCreateAsync() => throw new NotImplementedException();
            protected override Task<IActionResult> postDeleteAsync(string id, string? token = null) => throw new NotImplementedException();
            protected override Task<IActionResult> postEditAsync() => throw new NotImplementedException();
            protected override IActionResult redirectToDelete(string id) => throw new NotImplementedException();
            protected override IActionResult redirectToEdit(CountryView v) => throw new NotImplementedException();
            protected override IActionResult redirectToIndex() => throw new NotImplementedException();
            protected override void setAttributes(int idx, string? filter, string? order) {
                repo.PageIndex = idx;
                repo.CurrentFilter = filter;
                repo.CurrentOrder = order;
            }
            protected override Country toObject(CountryView? item) => throw new NotImplementedException();
            protected override CountryView toView(Country? entity) => throw new NotImplementedException();
        }
        protected override BasePage<CountryView, Country, ICountriesRepo> createObj() => new testClass(null);

        protected int idx;
        protected string? filter;
        protected string? order;
        protected string? id;
        protected string? expectedResult;
        [TestInitialize] public void InitializeBasePageTests() {
            idx = GetRandom.Int32();
            filter = GetRandom.String();
            order = GetRandom.String();
            id = Guid.NewGuid().ToString();
            expectedResult = "Faulted";

    }

    [TestMethod] public void BasePageTest() {
            var r = GetRepo.Instance<ICountriesRepo>();
            isNotNull(r);
            obj = new testClass(r);
            isNotNull(obj);
            areEqual(r, obj.repo);
        }


        [TestMethod] public void ErrorMessageTest() => isProperty<string?>();
        [TestMethod] public void TokenTest() => isReadOnly<byte>();
        [TestMethod] public void ItemIdTest() => isReadOnly<string>();
        [TestMethod] public void ItemsTest() => isProperty<IList<CountryView>>();
        [TestMethod] public void ItemTest() => isProperty<CountryView>();
        [TestMethod] public void OnGetCreateTest() {
            BasePageTest();
            obj.OnGetCreate(idx, filter, order);
            areEqual(idx, obj.repo.PageIndex);
            areEqual(filter, obj.repo.CurrentFilter);
            areEqual(order, obj.repo.CurrentOrder);
        }

        [TestMethod] public void OnPostCreateAsyncTest() {
            BasePageTest();
            var result = obj.OnPostCreateAsync(idx, filter, order);
            isNotNull(result);
            areEqual(expectedResult, result.Status.ToString());
            areEqual(idx, obj.repo.PageIndex);
            areEqual(filter, obj.repo.CurrentFilter);
            areEqual(order, obj.repo.CurrentOrder);
        }
        [TestMethod] public void OnGetDetailsAsyncTest() {
            BasePageTest();
            isNotNull(id);
            var result = obj.OnGetDetailsAsync(id, idx, filter, order);
            isNotNull(result);
            areEqual(expectedResult, result.Status.ToString());
            areEqual(idx, obj.repo.PageIndex);
            areEqual(filter, obj.repo.CurrentFilter);
            areEqual(order, obj.repo.CurrentOrder);

        }
        [TestMethod] public void OnGetDeleteAsyncTest() {
            BasePageTest();
            isNotNull(id);
            var result = obj.OnGetDeleteAsync(id, idx, filter, order);
            isNotNull(result);
            areEqual(expectedResult, result.Status.ToString());
            areEqual(idx, obj.repo.PageIndex);
            areEqual(filter, obj.repo.CurrentFilter);
            areEqual(order, obj.repo.CurrentOrder);
        }
        [TestMethod] public void OnPostDeleteAsyncTest() {
            BasePageTest();
            isNotNull(id);
            var result = obj.OnPostDeleteAsync(id, idx, filter, order);
            isNotNull(result);
            areEqual(expectedResult, result.Status.ToString());
            areEqual(idx, obj.repo.PageIndex);
            areEqual(filter, obj.repo.CurrentFilter);
            areEqual(order, obj.repo.CurrentOrder);
        }
        [TestMethod] public void OnGetEditAsyncTest() {
            BasePageTest();
            isNotNull(id);
            var result = obj.OnGetEditAsync(id, idx, filter, order);
            isNotNull(result);
            areEqual(expectedResult, result.Status.ToString());
            areEqual(idx, obj.repo.PageIndex);
            areEqual(filter, obj.repo.CurrentFilter);
            areEqual(order, obj.repo.CurrentOrder);
        }
        [TestMethod] public void OnPostEditAsyncTest() {
            BasePageTest();
            var result = obj.OnPostEditAsync(idx, filter, order);
            isNotNull(result);
            areEqual(expectedResult, result.Status.ToString());
            areEqual(idx, obj.repo.PageIndex);
            areEqual(filter, obj.repo.CurrentFilter);
            areEqual(order, obj.repo.CurrentOrder);
        }
        [TestMethod]
        public void OnGetIndexAsyncTest() {
            BasePageTest();
            var result = obj.OnGetIndexAsync(idx, filter, order);
            isNotNull(result);
            areEqual(expectedResult, result.Status.ToString());
            areEqual(idx, obj.repo.PageIndex);
            areEqual(filter, obj.repo.CurrentFilter);
            areEqual(order, obj.repo.CurrentOrder);
        }
    }

    [TestClass] public class CrudPageTests : AbstractClassTests<CrudPage<CountryView, Country, ICountriesRepo>, BasePage<CountryView, Country, ICountriesRepo>> {
        private CrudPage<CountryView, Country, ICountriesRepo>? page;
        private class testClass : CrudPage<CountryView, Country, ICountriesRepo> {
            public testClass(ICountriesRepo r) : base(r) { }
            protected override IActionResult redirectToDelete(string id) => throw new NotImplementedException();
            protected override IActionResult redirectToEdit(CountryView v) => throw new NotImplementedException();
            protected override IActionResult redirectToIndex() => throw new NotImplementedException();
            protected override void setAttributes(int idx, string? filter, string? order) => throw new NotImplementedException();
            protected override Country toObject(CountryView? item) => throw new NotImplementedException();
            protected override CountryView toView(Country? entity) => throw new NotImplementedException();
        }
        
        protected override CrudPage<CountryView, Country, ICountriesRepo> createObj() => page = new testClass(GetRepo.Instance<ICountriesRepo>());

        [TestMethod]
        public void CrudPageTest() {
            var r = GetRepo.Instance<ICountriesRepo>();
            isNotNull(r);
            obj = new testClass(r);
            areEqual(r, obj.repo);
        }
    }

    [TestClass] public class FilteredPageTests : AbstractClassTests<FilteredPage<CountryView, Country, ICountriesRepo>, CrudPage<CountryView, Country, ICountriesRepo>> {
        private FilteredPage<CountryView, Country, ICountriesRepo>? page;
        private class testClass : FilteredPage<CountryView, Country, ICountriesRepo> {

            public testClass(ICountriesRepo r): base(r) { }
            protected override IActionResult redirectToDelete(string id) => throw new NotImplementedException();
            protected override IActionResult redirectToEdit(CountryView v) => throw new NotImplementedException();
            protected override IActionResult redirectToIndex() => throw new NotImplementedException();
            protected override void setAttributes(int idx, string? filter, string? order) => throw new NotImplementedException();
            protected override Country toObject(CountryView? item) => throw new NotImplementedException();
            protected override CountryView toView(Country? entity) => throw new NotImplementedException();
        }
        protected override FilteredPage<CountryView, Country, ICountriesRepo> createObj()=> page = new testClass(GetRepo.Instance<ICountriesRepo>());
        [TestMethod] public void CurrentFilterTest() => isProperty<string?>();

    }

    [TestClass]
    public class OrderedPageTests : AbstractClassTests<OrderedPage<CountryView, Country, ICountriesRepo>, FilteredPage<CountryView, Country, ICountriesRepo>> {
        private OrderedPage<CountryView, Country, ICountriesRepo>? page;
        private class testClass : OrderedPage<CountryView, Country, ICountriesRepo> {
            public testClass(ICountriesRepo r): base(r) { }
            protected override IActionResult redirectToDelete(string id) => throw new NotImplementedException();
            protected override IActionResult redirectToEdit(CountryView v) => throw new NotImplementedException();
            protected override IActionResult redirectToIndex() => throw new NotImplementedException();
            protected override void setAttributes(int idx, string? filter, string? order) => throw new NotImplementedException();
            protected override Country toObject(CountryView? item) => throw new NotImplementedException();
            protected override CountryView toView(Country? entity) => throw new NotImplementedException();
        }
        protected override OrderedPage<CountryView, Country, ICountriesRepo> createObj() =>page = new testClass(GetRepo.Instance<ICountriesRepo>());
        [TestMethod] public void SortOrderTest() {
            var s = page?.SortOrder("Name");
            var expected = "Name_desc";
            areEqual(expected, s);
            expected = "Name_desc";
            var p = page?.SortOrder("English Name");
            areEqual(expected, p);
        }
        
        [TestMethod] public void CurrentOrderTest() {
            page.CurrentOrder = "Name";
            var s = page?.CurrentOrder;
            Assert.AreEqual("English Name", s);
            page.CurrentOrder = "English Name";
            s = page.CurrentOrder;
            Assert.AreEqual("English Name", s);
        }
    }
    

    [TestClass]
    public class PagedPageTests : AbstractClassTests<PagedPage<CountryView, Country, ICountriesRepo>, OrderedPage<CountryView, Country, ICountriesRepo>> {
        private PagedPage<CountryView, Country, ICountriesRepo>? page;
        private class testClass : PagedPage<CountryView, Country, ICountriesRepo> {
            public testClass(ICountriesRepo r): base(r) { }
            protected override Country toObject(CountryView? item) => throw new NotImplementedException();
            protected override CountryView toView(Country? entity) => throw new NotImplementedException();
            
        }
        protected override PagedPage<CountryView, Country, ICountriesRepo> createObj() =>page = new testClass(GetRepo.Instance<ICountriesRepo>());
        [TestMethod] public void GetValueTest() {
            var v = GetRandom.Value<CountryView>() ?? new CountryView(); 
            v.Description = "Testest";
            areEqual("Testest", page?.GetValue("Description", v));
        }
        [TestMethod] public void DisplayNameTest() => areEqual("Native Name", page?.DisplayName("Description"));
        [TestMethod] public void PageIndexTest() => isProperty<int>();
        [TestMethod] public void TotalPagesTest() {
            areEqual(0, page?.TotalPages);
            var data = addRandomItems<ICountriesRepo, Country, CountryData>(out int cnt, x => new Country(x));
            areEqual((int)Math.Ceiling(cnt/(double)10), page?.TotalPages);
        }
        [TestMethod] public void HasNextPageTest() => isReadOnly<bool>();
        [TestMethod] public void HasPreviousPageTest() => isReadOnly<bool>();
        [TestMethod] public void IndexColumnsTest() => isReadOnly<string>();
    }
    
}
