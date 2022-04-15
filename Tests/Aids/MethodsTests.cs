using App.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Aids
{
    [TestClass] public class MethodsTests : IsTypeTested {
        [TestMethod] public void HasAttributeTest() {
            var m = GetType().GetMethod(nameof(HasAttributeTest));
            isTrue(Methods.HasAttribute<TestMethodAttribute>(m));
            isFalse(Methods.HasAttribute<TestInitializeAttribute>(m));
        }
    }
}
