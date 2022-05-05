using App.Data.Party;
using App.Domain;
using App.Infra;
using App.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Infra.Initializers
{
    [TestClass] public class CurrenciesInitializerTests
        : SealedBaseTests<CurrenciesInitializer, BaseInitializer<CurrencyData>>
    {
        protected override CurrenciesInitializer createObj()
        {
            var db = GetRepo.Instance<AppDB>();
            return new CurrenciesInitializer(db);
        }
    }
}
