using App.Facade;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party
{
    [TestClass] public class CountryCurrencyViewTests : SealedClassTests<CountryCurrencyView, NamedView>
    {
        [TestMethod] public void CountryIdTest() => isRequired<string>("Country");
        [TestMethod] public void CurrencyIdTest() => isRequired<string>("Currency");
        [TestMethod] public void NameTest() => isDisplayNamed<string?>("Currency native name");
        [TestMethod] public void CodeTest() => isDisplayNamed<string?>("Currency code");
    }
}
