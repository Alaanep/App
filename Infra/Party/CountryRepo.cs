using App.Data.Party;
using App.Domain.Party;

namespace App.Infra.Party
{
    public partial class CountryRepo : Repo<Country, CountryData>, ICountryRepo
    {
        public CountryRepo(AppDB? db) : base(db, db?.Countries) { }
        protected override Country toDomain(CountryData d) => new(d);

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
