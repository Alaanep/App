using App.Data.Party;
using App.Domain.Party;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party
{
    [TestClass] public class CountryCurrencyViewFactoryTests
    : ViewFactoryTests<CountryCurrencyViewFactory, CountryCurrencyView, CountryCurrency, CountryCurrencyData>
    {
        protected override CountryCurrency toObject(CountryCurrencyData d) => new(d);
    }
}
