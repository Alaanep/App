using App.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Aids
{
    [TestClass] public class MethodsTests : TypeTests {
        [TestMethod] public void HasAttributeTest() {
            var m = GetType().GetMethod(nameof(HasAttributeTest));
            isTrue(Methods.HasAttribute<TestMethodAttribute>(m));
            isFalse(Methods.HasAttribute<TestInitializeAttribute>(m));
        }
        [TestMethod] public void GetAttributeTest()
        {
            var m = GetType().GetMethod(nameof(GetAttributeTest));
            isNotNull(Methods.GetAttribute<TestMethodAttribute>(m));
            isNull(Methods.GetAttribute<TestInitializeAttribute>(m));
        }
    }
}
