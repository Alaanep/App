using App.Data.Party;

namespace App.Domain.Party
{
    public interface ICountryCurrenciesRepo : IRepo<CountryCurrency> { }
    public sealed class CountryCurrency : NamedEntity<CountryCurrencyData>  {
        public CountryCurrency() : this(new ()) { }
        public CountryCurrency(CountryCurrencyData d) : base(d) { }
        public string CountryId => getValue(Data?.CountryId);
        public string CurrencyId => getValue(Data?.CurrencyId);
        public Country? Country => GetRepo.Instance<ICountryRepo>()?.Get(CountryId);
        public Currency? Currency => GetRepo.Instance<ICurrencyRepo>()?.Get(CountryId);
    }
}