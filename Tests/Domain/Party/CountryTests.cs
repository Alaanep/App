using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Domain.Party;

[TestClass]
public class CountryTests : SealedClassTests<Country, NamedEntity<CountryData>> {
    [TestMethod] public void CountryCurrenciesTest() => isInconclusive();
    [TestMethod] public void CurrenciesTest() => isInconclusive();
}