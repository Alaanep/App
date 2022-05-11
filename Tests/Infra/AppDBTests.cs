using App.Data.Party;
using App.Domain;
using App.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Infra
{
    [TestClass]
    public class AppDBTests : SealedBaseTests<AppDB, DbContext>
    {
        protected override AppDB createObj() => GetRepo.Instance<AppDB>();
        [TestMethod] public void InitializeTablesTest() => isInconclusive();
        [TestMethod] public void StudentsTest() => isProperty<DbSet<StudentData>>();
        [TestMethod] public void InstructorsTest() => isProperty<DbSet<InstructorData>>();
        [TestMethod] public void LessonsTest() => isProperty<DbSet<LessonData>>();
        [TestMethod] public void CountriesTest() => isProperty<DbSet<CountryData>>();
        [TestMethod] public void CurrenciesTest() => isProperty<DbSet<CurrencyData>>();
        [TestMethod] public void CountryCurrenciesTest() => isProperty<DbSet<CountryCurrencyData>>();
    }
}

