using App.Data.Party;
using App.Domain.Party;

namespace App.Infra.Party
{
    public sealed class CountryCurrenciesRepo : Repo<CountryCurrency, CountryCurrencyData>, ICountryCurrenciesRepo
    {
        public CountryCurrenciesRepo(AppDB? db) : base(db, db?.CountryCurrencies) { }
        protected override CountryCurrency toDomain(CountryCurrencyData d) => new(d);

        internal override IQueryable<CountryCurrencyData> addFilter(IQueryable<CountryCurrencyData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                    x => x.Id.Contains(y)
                         || x.Code.Contains(y)
                         || x.Name.Contains(y)
                         || x.Description.Contains(y)
                         || x.CountryId.Contains(y)
                         || x.CurrencyId.Contains(y));
        }
    }
}
