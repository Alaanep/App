using App.Data.Party;
using App.Domain.Party;

namespace App.Infra.Party
{
    public class CurrencyRepo : Repo<Currency, CurrencyData>, ICurrencyRepo
    {
        public CurrencyRepo(AppDB? db) : base(db, db?.Currencies) { }
        protected override Currency toDomain(CurrencyData d) => new(d);
    }
}
