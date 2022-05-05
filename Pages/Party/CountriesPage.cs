using App.Domain.Party;
using App.Facade.Party;

namespace App.Pages.Party {
    public class CountriesPage: PagedPage<CountryView, Country, ICountryRepo> {
        public CountriesPage(ICountryRepo r) : base(r) { }
        protected override Country toObject(CountryView? item) => new CountryViewFactory().Create(item);
        protected override CountryView toView(Country? entity) => new CountryViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CountryView.Code),
            nameof(CountryView.Name),
            nameof(CountryView.Description),
        };
        public Lazy<List<Currency?>> Currencies => toObject(Item).Currencies;
    }
}
