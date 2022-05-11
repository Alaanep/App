using App.Aids;
using App.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Aids {
    [TestClass]public class CopyTests: TypesTests {
        [TestMethod]public void PropertiesTest() {
            var obj = GetRandom.Value<StudentData>();
            isNotNull(obj);
            var copiedObj = new StudentData();
            Copy.Properties(obj, copiedObj);
            areEqualProperties(copiedObj, obj);
        }
    }
}
