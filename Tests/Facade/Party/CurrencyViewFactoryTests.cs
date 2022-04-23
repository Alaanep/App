using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Aids;
using App.Data.Party;
using App.Domain.Party;
using App.Facade;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party {
    [TestClass] public class CurrencyViewFactoryTests
        : ViewFactoryTests<CurrencyViewFactory, CurrencyView, Currency, CurrencyData>
    {
        protected override Currency toObject(CurrencyData d) => new(d);
    }
}
