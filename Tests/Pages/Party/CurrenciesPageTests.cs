using App.Domain;
using App.Domain.Party;
using App.Facade.Party;
using App.Pages;
using App.Pages.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace App.Tests.Pages.Party {
    [TestClass]
    public class CurrenciesPageTests : SealedBaseTests<CurrenciesPage, PagedPage<CurrencyView, Currency, ICurrenciesRepo>> {

        private CurrenciesPage? page;
        protected override CurrenciesPage createObj() => page =new CurrenciesPage(GetRepo.Instance<ICurrenciesRepo>());

        [TestMethod]
        public void IndexColumnsTest() {
            var arr = new string[] { "Code", "Symbol", "Name", "Description" };
            for (var i = 0; i < arr.Length; i++) {
                areEqual(arr[i], page?.IndexColumns[i]);
            }
        }
        [TestMethod]
        public void CountriesTest() =>
            isReadOnly<Lazy<List<Country?>>>();
    }
}
