using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Aids;
using App.Data.Party;
using App.Domain.Party;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party {
    [TestClass]
    public class CurrencyViewFactoryTests: SealedClassTests<CurrencyView> {
        [TestMethod]
        public void CreateViewTest() {
            var d = GetRandom.Value<CurrencyData>();
            var e = new Currency(d);
            var v = new CurrencyViewFactory().Create(e);
            isNotNull(v);
            //todo motelge
            //arePropertiesEqual(v, e, nameof(v.fullName))
            areEqual(v.Id, e.Id);
            areEqual(v.Code, e.Code);
            areEqual(v.Name, e.Name);
            areEqual(v.Description, e.Description);
            areEqual(v.Symbol, e.Symbol);

        }
        [TestMethod]
        public void CreateEntityTest() {
            var v = GetRandom.Value<CurrencyData>();
            var e = new CurrencyViewFactory().Create(v);
            isNotNull(e);
            //todo motelge
            //arePropertiesEqual(v, e)
            areEqual(e.Id, v?.Id);
            areEqual(e.Code, v?.Code);
            areEqual(e.Name, v?.Name);
            areEqual(e.Description, v?.Description);
            areEqual(e.Symbol, v?.Symbol);
        }
    }
}
