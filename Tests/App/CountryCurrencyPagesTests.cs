using App.Data.Party;
using App.Domain.Party;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace App.Tests.App {
    [TestClass]
    public class CountryCurrencyPagesTests : PagesTests<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData, CountryCurrencyView> {
        protected override string? handlerName { get; set; } = "CountryCurrencies";
        protected override CountryCurrencyData? data { get; set; }
        [TestInitialize]
        public void Initialize() {
            data = addRandomItems<ICountryCurrenciesRepo, CountryCurrency, CountryCurrencyData>(out int cnt, x => new CountryCurrency(x), id);
        }
        [TestMethod]
        public override async Task GetEditPageTest() {
            await base.GetEditPageTest();
            isNotNull(data);
            isNotNull(html);
            isNotNull(data.Code);
            isNotNull(data.Name);
            isTrue(html.Contains(data.Id));
            isTrue(html?.Contains(data.Code));
            isTrue(html?.Contains(data.Name));
        }

        [TestMethod]
        public override async Task GetDetailsPageTest() {
            await base.GetDetailsPageTest();
            isNotNull(data);
            isNotNull(html);
            isNotNull(data.Code);
            isNotNull(data.Name);
            isTrue(html.Contains(data.Id));
            isTrue(html?.Contains(data.Code));
            isTrue(html?.Contains(data.Name));
        }
        [TestMethod]
        public override async Task GetDeletePageTest() {
            await base.GetDeletePageTest();
            isNotNull(data);
            isNotNull(html);
            isNotNull(data.Code);
            isNotNull(data.Name);
            isTrue(html.Contains(data.Id));
            isTrue(html?.Contains(data.Code));
            isTrue(html?.Contains(data.Name));
        }

        [TestMethod]
        public override async Task GetCreatePageTest() {
            await base.GetCreatePageTest();
            isNotNull(data);
            isNotNull(html);
            isTrue(html?.Contains(nameof(CountryCurrency.Code)));
            isTrue(html?.Contains(nameof(CountryCurrency.Name)));
            isTrue(html?.Contains(nameof(CountryCurrency.CountryId)));
            isTrue(html?.Contains(nameof(CountryCurrency.CurrencyId)));
        }
    }
}
 
