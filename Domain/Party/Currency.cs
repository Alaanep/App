using App.Data.Party;

namespace App.Domain.Party {
    public sealed class Currency : NamedEntity<CurrencyData> {
        public Currency() : this(new ()) { }
        public Currency(CurrencyData d) : base(d) { }
        public string Symbol => getValue(Data?.Symbol);
        public List<CountryCurrency> CountryCurrencies
            => GetRepo.Instance<ICountryCurrenciesRepo>()?
            .GetAll(x => x.CurrencyId)?
            .Where(x => x.CurrencyId == Id)?
            .ToList() ?? new List<CountryCurrency>();

        public List<Country?> Countries
            => CountryCurrencies
            .Select(x => x.Country)
            .ToList() ?? new List<Country?>();
    }
}
