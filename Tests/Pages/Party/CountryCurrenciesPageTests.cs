using App.Aids;
using App.Data.Party;
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

        [TestMethod] public void CountryNameTest() {
            var id = GetRandom.String();
            var data = addRandomItems<ICountriesRepo, Country, CountryData>(out int cnt, x => new Country(x), id);
            isNotNull(data);
            var expectedName = data?.Name;
            areEqual(expectedName, page?.CountryName(id));
            data = addRandomItems<ICountriesRepo, Country, CountryData>(out cnt, x => new Country(x));
            areEqual(expectedName, page?.CountryName(id));
            areNotEqual(GetRandom.String(), page?.CountryName(id));

        }
        [TestMethod] public void CurrencyNameTest() {
            var id = GetRandom.String();
            var data = addRandomItems<ICurrenciesRepo, Currency, CurrencyData>(out int cnt, x => new Currency(x), id);
            isNotNull(data);
            var expectedName = data?.Name;
            areEqual(expectedName, page?.CurrencyName(id));
            data = addRandomItems<ICurrenciesRepo, Currency, CurrencyData>(out cnt, x => new Currency(x));
            areEqual(expectedName, page?.CurrencyName(id));
            areNotEqual(GetRandom.String(), page?.CurrencyName(id));
        }
        [TestMethod] public void GetValueTest() {
            var v = GetRandom.Value<CountryCurrencyView>() ?? new CountryCurrencyView();
            v.Name = "Testest";
            areEqual("Testest", page?.GetValue("Name", v));
            areNotEqual("Testests", page?.GetValue("Name", v));
        }
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
