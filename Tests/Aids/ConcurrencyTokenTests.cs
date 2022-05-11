using App.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Aids {
    [TestClass] public class ConcurrencyTokenTests : TypesTests {
        [TestMethod] public void ToStrTest(){
            var token = GetRandom.Value<byte[]>();
            string s = ConcurrencyToken.ToStr(token);
            isNotNull(s);
            areEqual(typeof(string), s.GetType());
        }
        [TestMethod] public void ToByteArrayTest() {
            var s = GetRandom.String(8, 8);
            var arr = ConcurrencyToken.ToByteArray(s);
            isNotNull(arr);
            areEqual(typeof(byte[]), arr.GetType());
            areEqual(8, arr.Length);
        }
    }
}
