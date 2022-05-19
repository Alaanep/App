using App.Aids;
using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using App.Facade.Party;
using App.Infra.Party;
using App.Pages;
using App.Pages.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace App.Tests.Pages.Party {
    [TestClass]
    public class CountriesPageTests : SealedBaseTests<CountriesPage, PagedPage<CountryView, Country, ICountriesRepo>> {
        private CountriesPage? page;
        protected override CountriesPage createObj() => page = new CountriesPage(GetRepo.Instance<ICountriesRepo>());

        [TestMethod] public void IndexColumnsTest() {
            var arr = new string[] { "Code", "Name", "Description" };
            for (var i = 0; i < arr.Length; i++) {
                areEqual(arr[i], page?.IndexColumns[i]);
            }
        }
        [TestMethod] public void CurrenciesTest() { 
            isReadOnly<Lazy<List<Currency?>>>();
            var l = page?.Currencies;
            var data = addRandomItems<ICurrenciesRepo, Currency, CurrencyData>(out int cnt, x => new Currency(x));
            l = page?.Currencies;
            isNotNull(page?.Currencies);
        }
    }
}
