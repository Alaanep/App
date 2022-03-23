using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party {
    [TestClass]
    public class CountryViewTests: SealedClassTests<CountryView> {
        [TestMethod] public void NameTest() => isProperty<string>();
        [TestMethod] public void CodeTest() => isProperty<string>();
        [TestMethod] public void DescriptionTest() => isProperty<string>();
    }
}
