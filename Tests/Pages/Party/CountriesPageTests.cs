using App.Domain.Party;
using App.Facade.Party;
using App.Infra.Party;
using App.Pages;
using App.Pages.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Pages.Party {
    [TestClass]
    public class CountriesPageTests : SealedBaseTests<CountriesPage, PagedPage<CountryView, Country, ICountriesRepo>> {
        protected override CountriesPage createObj() => new CountriesPage(null);
    }
}
