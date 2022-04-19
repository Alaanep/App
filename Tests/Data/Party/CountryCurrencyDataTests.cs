using App.Data;
using App.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Data.Party
{
    [TestClass]
    public class CountryCurrencyDataTests : SealedClassTests<CountryCurrencyData, NamedData>
    {
        [TestMethod] public void CountryIdTest() => isProperty<string>();
        [TestMethod] public void CurrencyIdTest() => isProperty<string>();
    }

}
