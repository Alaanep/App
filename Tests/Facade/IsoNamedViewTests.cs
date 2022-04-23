using App.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade
{
    [TestClass] public class IsoNamedViewTests : AbstractClassTests<IsoNamedView, NamedView>
    {
        private class testClass : IsoNamedView { }
        protected override IsoNamedView createObj() => new testClass();
        [TestMethod] public void NameTest() => isDisplayNamed<string>("English Name");
        [TestMethod] public void DescriptionTest() => isDisplayNamed<string>("Native Name");
        [TestMethod] public void CodeTest() => isRequired<string>("Code");

    }
}
