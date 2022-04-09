using App.Data.Party;

namespace App.Domain.Party
{
    public interface ICountryRepo : IRepo<Country> { }

    public sealed class Country : NamedEntity<CountryData>
    {
        public Country() : this(new()) { }
        public Country(CountryData d) : base(d) { }
        public List<CountryCurrency> CountryCurrencies
            => GetRepo.Instance<ICountryCurrenciesRepo>()?
            .GetAll(x => x.CountryId)?
            .Where(x => x.CountryId == Id)?
            .ToList() ?? new List<CountryCurrency>();
        public List<Currency?> Currencies
            => CountryCurrencies
            .Select(x => x.Currency)
            .ToList() ?? new List<Currency?>();
    }
}