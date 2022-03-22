using App.Data.Party;
using App.Domain.Party;

namespace App.Infra.Party {
    public  class CountryRepo: Repo<Country, CountryData>, ICountryRepo {
        public CountryRepo(AppDB? db) : base(db, db?.Countries) { }
        protected override Country toDomain(CountryData d) => new(d);
    }
}
