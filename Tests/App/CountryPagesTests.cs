using App.Data.Party;
using App.Domain.Party;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace App.Tests.App {
    [TestClass]
    public class CountryPagesTests : PagesTests<ICountriesRepo, Country, CountryData, CountryView> {
        protected override string handlerName { get; set; } = "Countries";
        protected override CountryData? data { get; set; }
        [TestInitialize]
        public void Initialize() {
            data = addRandomItems<ICountriesRepo, Country, CountryData>(out int cnt, x => new Country(x), id);
        }
        [TestMethod]
        public override async Task GetEditPageTest() {
            await base.GetEditPageTest();
            isNotNull(data);
            isNotNull(html);
            isTrue(html?.Contains(data?.Code));
            isTrue(html?.Contains(data?.Description));
            isTrue(html?.Contains(data?.Name));
        }

        [TestMethod]
        public override async Task GetDetailsPageTest() {
            await base.GetDetailsPageTest();
            isNotNull(data);
            isNotNull(html);
            isTrue(html?.Contains(data?.Code));
            isTrue(html?.Contains(data?.Description));
            isTrue(html?.Contains(data?.Name));
        }
        [TestMethod]
        public override async Task GetDeletePageTest() {
            await base.GetDeletePageTest();
            isNotNull(data);
            isNotNull(html);
            isTrue(html?.Contains(data?.Code));
            isTrue(html?.Contains(data?.Description));
            isTrue(html?.Contains(data?.Name));
        }
    }
}
 
