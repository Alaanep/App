using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using App.Infra;
using App.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Infra.Party
{
    public abstract class SealedRepoTests<TClass, TBaseClass> : SealedBaseTests<TClass, TBaseClass> where TClass : class where TBaseClass : class { }
    [TestClass]
    public class StudentsRepoTests : SealedRepoTests<StudentsRepo, Repo<Student, StudentData>>{
        protected override StudentsRepo createObj() => new(GetRepo.Instance<AppDB>());
    }

    [TestClass]
    public class CountriesRepoTests : SealedRepoTests<CountriesRepo, Repo<Country, CountryData>>
    {
        protected override CountriesRepo createObj() => new(GetRepo.Instance<AppDB>());
    }

    [TestClass]
    public class CountryCurrenciesRepoTests : SealedRepoTests<CountryCurrenciesRepo, Repo<CountryCurrency, CountryCurrencyData>>{
        protected override CountryCurrenciesRepo createObj() => new(GetRepo.Instance<AppDB>());
    }

    [TestClass]
    public class CurrenciesRepoTests : SealedRepoTests<CurrenciesRepo, Repo<Currency, CurrencyData>>
    {
        protected override CurrenciesRepo createObj() => new(GetRepo.Instance<AppDB>());
    }

    [TestClass]
    public class InstructorsRepoTests : SealedRepoTests<InstructorsRepo, Repo<Instructor, InstructorData>>
    {
        protected override InstructorsRepo createObj() => new(GetRepo.Instance<AppDB>());
    }

    [TestClass]
    public class LessonsRepoTests : SealedRepoTests<LessonsRepo, Repo<Lesson, LessonData>>
    {
        protected override LessonsRepo createObj() => new(GetRepo.Instance<AppDB>());
    }
}
