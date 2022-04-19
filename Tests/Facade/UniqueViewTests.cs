using App.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade {
    [TestClass]
    public class UniqueViewTests : AbstractClassTests<UniqueView, object> {
        protected override UniqueView createObj() => new testClass();
        private class testClass : UniqueView { }
    }
}
