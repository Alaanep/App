using App.Domain.Party;
using App.Facade.Party;
using App.Pages;
using App.Pages.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Pages.Party {
    [TestClass]
    public class CountryCurrenciesPageTests : SealedBaseTests<CountryCurrenciesPage, PagedPage<CountryCurrencyView, CountryCurrency, ICountryCurrenciesRepo>>  {
        protected override CountryCurrenciesPage createObj() => new CountryCurrenciesPage(null, null, null);
    }
}
