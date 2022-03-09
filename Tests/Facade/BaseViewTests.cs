using App.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade {
    [TestClass]
    public class BaseViewTests : AbstractClassTests {
        protected override object createObj() => new testClass();
        private class testClass : BaseView { }
    }
}
