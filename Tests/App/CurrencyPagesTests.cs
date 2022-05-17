using App.Data.Party;
using App.Domain.Party;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace App.Tests.App {
    [TestClass]
    public class CurrencyPagesTests : PagesTests<ICurrenciesRepo, Currency, CurrencyData, CurrencyView> {
        protected override string handlerName { get; set; } = "Currencies";

        protected override CurrencyData? data { get; set; }
        [TestInitialize]
        public void Initialize() {
            data = addRandomItems<ICurrenciesRepo, Currency, CurrencyData>(out int cnt, x => new Currency(x), id);
        }
        [TestMethod]
        public override async Task GetEditPageTest() {
            await base.GetEditPageTest();
            isNotNull(data);
            isNotNull(html);
            isTrue(html.Contains(data.Id));
            isTrue(html.Contains(data.Code));
            isTrue(html.Contains(data.Description));
            isTrue(html.Contains(data.Name));
        }
        [TestMethod]
        public override async Task GetDetailsPageTest() {
            await base.GetDetailsPageTest();
            isNotNull(data);
            isNotNull(html);
            isTrue(html.Contains(data.Id));
            isTrue(html.Contains(data?.Code));
            isTrue(html.Contains(data?.Description));
            isTrue(html.Contains(data?.Name));
        }
        [TestMethod]
        public override async Task GetDeletePageTest() {
            await base.GetDeletePageTest();
            isNotNull(data);
            isNotNull(html);
            isTrue(html.Contains(data.Id));
            isTrue(html.Contains(data?.Code));
            isTrue(html.Contains(data?.Description));
            isTrue(html.Contains(data?.Name));
        }

        [TestMethod] public override async Task GetCreatePageTest() {
            await base.GetCreatePageTest();
            isNotNull(data);
            isNotNull(html);
            var a = nameof(Country.Description);
            isTrue(html.Contains(nameof(Currency.Code)));
            isTrue(html.Contains(nameof(Currency.Description)));
            isTrue(html.Contains(nameof(Currency.Name)));
        }

    }
}
 
