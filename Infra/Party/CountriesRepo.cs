using App.Data.Party;
using App.Domain.Party;

namespace App.Infra.Party
{
    public  sealed class CountriesRepo : Repo<Country, CountryData>, ICountryRepo
    {
        public CountriesRepo(AppDB? db) : base(db, db?.Countries) { }
        protected internal override Country toDomain(CountryData d) => new(d);

        internal override IQueryable<CountryData> addFilter(IQueryable<CountryData> q) {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
                x => x.Id.Contains(y)
                     || x.Code.Contains(y)
                     || x.Name.Contains(y)
                     || x.Description.Contains(y));
        }
    }
}
