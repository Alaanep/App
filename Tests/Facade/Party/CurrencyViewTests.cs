using App.Facade;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party {
    [TestClass] public class CurrencyViewTests: SealedClassTests<CurrencyView, IsoNamedView> {
        [TestMethod] public void SymbolTest() => isDisplayNamed<string>("Symbol");
    }
}
