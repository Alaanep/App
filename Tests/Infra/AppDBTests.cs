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
        [TestMethod] public void InitializeTablesTest() => isInconclusive();
        [TestMethod] public void StudentsTest() => isInconclusive();
        [TestMethod] public void InstructorsTest() => isInconclusive();
        [TestMethod] public void LessonsTest() => isInconclusive();
        [TestMethod] public void CountriesTest() => isInconclusive();
        [TestMethod] public void CurrenciesTest() => isInconclusive();
        [TestMethod] public void CountryCurrenciesTest() => isInconclusive();
    }
}

