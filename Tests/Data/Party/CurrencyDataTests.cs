using App.Data;
using App.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Data.Party {
    [TestClass]
    public class CurrencyDataTests: SealedClassTests<CurrencyData, NamedData> { 
        [TestMethod] public void SymbolTest() => isProperty<string>();
    }
}
