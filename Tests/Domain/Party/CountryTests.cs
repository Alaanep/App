using App.Aids;
using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace App.Tests.Domain.Party;

[TestClass] public class CountryTests : SealedClassTests<Country, NamedEntity<CountryData>> {
    protected override Country createObj() => new(GetRandom.Value<CountryData>());
    [TestMethod] public void CountryCurrenciesTest() 
        => itemsTest<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData> (
            d => d.CountryId = obj.Id, d=> new CountryCurrency(d), () => obj.CountryCurrencies);

    [TestMethod] public void CurrenciesTest() => isInconclusive();
}