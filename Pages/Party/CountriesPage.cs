using App.Domain.Party;
using App.Facade.Party;

namespace App.Pages.Party {
    public class CountriesPage: PagedPage<CountryView, Country, ICountryRepo> {
        public CountriesPage(ICountryRepo r) : base(r) { }
        protected override Country toObject(CountryView? item) => new CountryViewFactory().Create(item);
        protected override CountryView toView(Country? entity) => new CountryViewFactory().Create(entity);
    }
}
