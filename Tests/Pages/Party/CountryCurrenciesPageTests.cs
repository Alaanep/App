using App.Domain;
using App.Domain.Party;
using App.Facade.Party;
using App.Pages;
using App.Pages.Party;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace App.Tests.Pages.Party {
    [TestClass]
    public class CountryCurrenciesPageTests : SealedBaseTests<CountryCurrenciesPage, PagedPage<CountryCurrencyView, CountryCurrency, ICountryCurrenciesRepo>> {
        private CountryCurrenciesPage? page;
        protected override CountryCurrenciesPage createObj() =>
            page = new CountryCurrenciesPage(GetRepo.Instance<ICountryCurrenciesRepo>(), GetRepo.Instance<ICountriesRepo>(), GetRepo.Instance<ICurrenciesRepo>());

        [TestMethod] public void CountryNameTest() => isInconclusive();
        [TestMethod] public void CurrencyNameTest() => isInconclusive();
        [TestMethod] public void GetValueTest() => isInconclusive();
        [TestMethod] public void IndexColumnsTest(){
            var arr = new string[] { "Code", "Name", "CountryId", "CurrencyId", "Description" };
            for (var i = 0; i<arr.Length; i++) {
                areEqual(arr[i], page?.IndexColumns[i]);
            }
        }
        [TestMethod] public void CountriesTest() => isReadOnly<IEnumerable<SelectListItem>>();
        [TestMethod] public void CurrenciesTest() => isReadOnly<IEnumerable<SelectListItem>>();

    }
}
