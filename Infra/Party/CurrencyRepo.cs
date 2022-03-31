using App.Data.Party;
using App.Domain.Party;

namespace App.Infra.Party
{
    public class CurrencyRepo : Repo<Currency, CurrencyData>, ICurrencyRepo
    {
        public CurrencyRepo(AppDB? db) : base(db, db?.Currencies) { }
        protected override Currency toDomain(CurrencyData d) => new(d);
        internal override IQueryable<CurrencyData> addFilter(IQueryable<CurrencyData> q)
        {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
                x => x.Id.Contains(y)
                || x.Code.Contains(y)
                || x.Symbol.Contains(y)
                || x.Name.Contains(y)
                || x.Description.Contains(y));
        }

    }
}
