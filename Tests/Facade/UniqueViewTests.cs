using App.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade
{
    [TestClass]
    public class UniqueViewTests : AbstractClassTests<UniqueView, object> {
        private class testClass : UniqueView { }
        protected override UniqueView createObj() => new testClass();
        [TestMethod] public void IdTest() => isProperty<string>();
    }
}
