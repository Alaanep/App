using App.Aids;
using App.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Aids {
    [TestClass] public class EnumsTests : IsTypeTested {
            [TestMethod] public void DescriptionTests()
                => areEqual("Not Known", Enums.Description(Level.NotKnown));

            [TestMethod] public void ToStringTest()
                => areEqual("NotKnown", Level.NotKnown.ToString());
    }
}
