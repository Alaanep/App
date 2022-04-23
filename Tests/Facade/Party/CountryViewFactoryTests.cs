using App.Aids;
using App.Data.Party;
using App.Domain.Party;
using App.Facade;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party
{
    [TestClass] public class CountryViewFactoryTests
        : ViewFactoryTests<CountryViewFactory, CountryView, Country, CountryData>
    {
        protected override Country toObject(CountryData d) => new(d);
    }
}
