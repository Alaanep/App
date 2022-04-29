using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using App.Infra;
using App.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Infra.Party
{
    [TestClass]
    public class CountriesRepoTests : SealedRepoTests<CountriesRepo, Repo<Country, CountryData>, Country, CountryData>
    {
        protected override CountriesRepo createObj() => new(GetRepo.Instance<AppDB>());
        protected override object? getSet(AppDB db) => db.Countries;
    }
}
