using App.Data.Party;
using App.Domain.Party;

namespace App.Infra.Party {
    public  class CountryRepo: Repo<Country, CountryData>, ICountryRepo {
        public CountryRepo(AppDB? db) : base(db, db?.Countries) { }
        protected override Country toDomain(CountryData d) => new(d);

        internal override IQueryable<CountryData> addFilter(IQueryable<CountryData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q
                : q.Where(
                    x => contains(x.Id, y)
                         || contains(x.Code, y)
                         || contains(x.Name, y)
                         || contains(x.Description, y));
        }

        /*internal override IQueryable<CountryData> addFilter(IQueryable<CountryData> q) {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
                x => x.Id.Contains(y)
                     || x.Code.Contains(y)
                     || x.Name.Contains(y)
                     || x.Description.Contains(y));
        }*/
    }
}
