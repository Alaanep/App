using App.Domain.Party;
using App.Facade.Party;
using App.Infra.Party;
using App.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace App.Tests.Pages {
    [TestClass] public class BasePageTests : AbstractClassTests<BasePage<CountryView, Country, ICountriesRepo>, PageModel> {

        private class testClass : BasePage<CountryView, Country, ICountriesRepo> {
            public testClass(ICountriesRepo r) : base(r) { }
            protected override IActionResult getCreate() => throw new NotImplementedException();
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
            protected override void setAttributes(int idx, string? filter, string? order) => throw new NotImplementedException();
            protected override Country toObject(CountryView? item) => throw new NotImplementedException();
            protected override CountryView toView(Country? entity) => throw new NotImplementedException();
        }
        protected override BasePage<CountryView, Country, ICountriesRepo> createObj() => new testClass(null);
    }

    [TestClass] public class CrudPageTests : AbstractClassTests<CrudPage<CountryView, Country, ICountriesRepo>, BasePage<CountryView, Country, ICountriesRepo>> {

        private class testClass : CrudPage<CountryView, Country, ICountriesRepo> {
            public testClass(ICountriesRepo r) : base(r) { }
            protected override IActionResult redirectToDelete(string id) => throw new NotImplementedException();
            protected override IActionResult redirectToEdit(CountryView v) => throw new NotImplementedException();
            protected override IActionResult redirectToIndex() => throw new NotImplementedException();
            protected override void setAttributes(int idx, string? filter, string? order) => throw new NotImplementedException();
            protected override Country toObject(CountryView? item) => throw new NotImplementedException();
            protected override CountryView toView(Country? entity) => throw new NotImplementedException();
        }
        protected override CrudPage<CountryView, Country, ICountriesRepo> createObj() => new testClass(null);
    }

    [TestClass] public class FilteredPageTests : AbstractClassTests<FilteredPage<CountryView, Country, ICountriesRepo>, CrudPage<CountryView, Country, ICountriesRepo>> {

        private class testClass : FilteredPage<CountryView, Country, ICountriesRepo> {

            public testClass(ICountriesRepo r): base(r) { }
            protected override IActionResult redirectToDelete(string id) => throw new NotImplementedException();
            protected override IActionResult redirectToEdit(CountryView v) => throw new NotImplementedException();
            protected override IActionResult redirectToIndex() => throw new NotImplementedException();
            protected override void setAttributes(int idx, string? filter, string? order) => throw new NotImplementedException();
            protected override Country toObject(CountryView? item) => throw new NotImplementedException();
            protected override CountryView toView(Country? entity) => throw new NotImplementedException();
        }
        protected override FilteredPage<CountryView, Country, ICountriesRepo> createObj()=> new testClass(null);
    }

    [TestClass]
    public class OrderedPageTests : AbstractClassTests<OrderedPage<CountryView, Country, ICountriesRepo>, FilteredPage<CountryView, Country, ICountriesRepo>> {

        private class testClass : OrderedPage<CountryView, Country, ICountriesRepo> {

            public testClass(ICountriesRepo r): base(r) { }
            protected override IActionResult redirectToDelete(string id) => throw new NotImplementedException();
            protected override IActionResult redirectToEdit(CountryView v) => throw new NotImplementedException();
            protected override IActionResult redirectToIndex() => throw new NotImplementedException();
            protected override void setAttributes(int idx, string? filter, string? order) => throw new NotImplementedException();
            protected override Country toObject(CountryView? item) => throw new NotImplementedException();
            protected override CountryView toView(Country? entity) => throw new NotImplementedException();
        }
        protected override OrderedPage<CountryView, Country, ICountriesRepo> createObj() => new testClass(null);
    }
    

    [TestClass]
    public class PagedPageTests : AbstractClassTests<PagedPage<CountryView, Country, ICountriesRepo>, OrderedPage<CountryView, Country, ICountriesRepo>> {

        private class testClass : PagedPage<CountryView, Country, ICountriesRepo> {
            public testClass(ICountriesRepo r): base(r) { }
            protected override Country toObject(CountryView? item) => throw new NotImplementedException();
            protected override CountryView toView(Country? entity) => throw new NotImplementedException();
            
        }
        protected override PagedPage<CountryView, Country, ICountriesRepo> createObj() => new testClass(null);
    }
    
}
