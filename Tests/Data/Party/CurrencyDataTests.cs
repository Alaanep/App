using App.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Data.Party {
    [TestClass]
    public class CurrencyDataTests: SealedClassTests<CurrencyData> { 
        [TestMethod] public void SymbolTest() => isProperty<string>();
    }
}
