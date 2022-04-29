using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using App.Infra;
using App.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Infra.Party
{
    [TestClass]
    public class CountryCurrenciesRepoTests : SealedRepoTests<CountryCurrenciesRepo, Repo<CountryCurrency, CountryCurrencyData>, CountryCurrency, CountryCurrencyData>
    {
        protected override CountryCurrenciesRepo createObj() => new(GetRepo.Instance<AppDB>());
        protected override object? getSet(AppDB db) => db.CountryCurrencies;
    }
}
