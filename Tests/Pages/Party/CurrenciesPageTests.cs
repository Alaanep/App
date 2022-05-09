using App.Domain.Party;
using App.Facade.Party;
using App.Pages;
using App.Pages.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Pages.Party {
    [TestClass]
    public class CurrenciesPageTests : SealedBaseTests<CurrenciesPage, PagedPage<CurrencyView, Currency, ICurrenciesRepo>> {
        protected override CurrenciesPage createObj() => new CurrenciesPage(null);
    }
}
