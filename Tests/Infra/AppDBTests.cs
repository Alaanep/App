using App.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Infra
{
    [TestClass]
    public class AppDBTests : SealedBaseTests<AppDB, DbContext>
    {
        protected override AppDB createObj() => null;
        protected override void isSealedTest() => isInconclusive();
    }
}

