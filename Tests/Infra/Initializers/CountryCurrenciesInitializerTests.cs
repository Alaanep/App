using App.Data.Party;
using App.Domain;
using App.Infra;
using App.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Infra.Initializers
{
    [TestClass] public class CountryCurrenciesInitializerTests
        : SealedBaseTests<CountryCurrenciesInitializer, BaseInitializer<CountryCurrencyData>>
    {
        protected override CountryCurrenciesInitializer createObj()
        {
            var db = GetRepo.Instance<AppDB>();
            return new CountryCurrenciesInitializer(db);
        }
    }
}
