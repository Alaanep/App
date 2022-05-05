using App.Aids;
using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Domain.Party;

[TestClass]
public class CountryCurrencyTests : SealedClassTests<CountryCurrency, NamedEntity<CountryCurrencyData>> {
    protected override CountryCurrency createObj() => new (GetRandom.Value<CountryCurrencyData>());

    [TestMethod] public void CountryIdTest() => isReadOnly(obj.Data.CountryId);
    [TestMethod] public void CurrencyIdTest() => isReadOnly(obj.Data.CurrencyId);
    [TestMethod]
    public void CountryTest() => itemTest<ICountriesRepo, Country, CountryData>(
        obj.CountryId, d => new Country(d), () => obj.Country);
    [TestMethod]
    public void CurrencyTest() => itemTest<ICurrenciesRepo, Currency, CurrencyData>(
        obj.CurrencyId, d => new Currency(d), () => obj.Currency);

} 