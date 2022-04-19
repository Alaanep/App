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
    [TestMethod] public void CountryTest() => isInconclusive();
    [TestMethod] public void CurrencyTest() => isInconclusive();
}