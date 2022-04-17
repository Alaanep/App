using App.Aids;
using App.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Data.Party
{
    [TestClass]
    public class LevelTests : IsTypeTested
    {
        [TestMethod] public void B1Test() => doTest(Level.B1, 1, "B1");
        [TestMethod] public void B2Test() => doTest(Level.B2, 2, "B2");
        [TestMethod] public void B3Test() => doTest(Level.B3, 3, "B3");
        [TestMethod] public void RefresherTest() => doTest(Level.Refresher, 4, "Refresher");
        [TestMethod] public void SnowkiteTest() => doTest(Level.Snowkite, 5, "Snowkite");
        [TestMethod] public void NotKnownTest() => doTest(Level.NotKnown, 6, "Not Known");
        private static void doTest(Level level, int value, string description)
        {
            areEqual(value, (int)level);
            areEqual(description, level.Description());
        }
    }
}

