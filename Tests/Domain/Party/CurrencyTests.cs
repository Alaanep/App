using App.Aids;
using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Domain.Party;

[TestClass] public class CurrencyTests : SealedClassTests<Currency, NamedEntity<CurrencyData>> {
    protected override Currency createObj() => new (GetRandom.Value<CurrencyData>());

    [TestMethod] public void SymbolTest() => isReadOnly(obj.Data.Symbol);
    [TestMethod] public void CountryCurrenciesTest() => isInconclusive();
    [TestMethod] public void CountriesTest() => isInconclusive();
}