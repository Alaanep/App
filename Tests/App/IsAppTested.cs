using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.App
{
    [TestClass]
    public class IsAppTested:AssemblyTests
    {
        protected override void isAllTested() => isInconclusive("Namespace has to be changed to \"App.App\"");
    }
}
