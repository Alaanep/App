using App.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Data.Party {
    internal class CurrencyDataTests: SealedClassTests<CurrencyData> {
        [TestMethod] public void NameTest() => isProperty<string>();
        [TestMethod] public void CodeTest() => isProperty<string>();
        [TestMethod] public void DescriptionTest() => isProperty<string>();
        [TestMethod] public void SymbolTest() => isProperty<string>();
    }
}
