using App.Data.Party;
using App.Domain;
using App.Infra;
using App.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Infra.Initializers
{
    [TestClass] public class CountriesInitializerTests
        : SealedBaseTests<CountriesInitializer, BaseInitializer<CountryData>>
    {
        protected override CountriesInitializer createObj()
        {
            var db = GetRepo.Instance<AppDB>();
            return new CountriesInitializer(db);
        }
    }
}
