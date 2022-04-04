using App.Domain.Party;
using App.Facade.Party;

namespace App.Pages.Party
{
    public class CurrenciesPage : PagedPage<CurrencyView, Currency, ICurrencyRepo>  {
        public CurrenciesPage(ICurrencyRepo r) : base(r) { }
        protected override Currency toObject(CurrencyView? item) => new CurrencyViewFactory().Create(item);
        protected override CurrencyView toView(Currency? entity) => new CurrencyViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(CurrencyView.Code),
            nameof(CurrencyView.Symbol),
            nameof(CurrencyView.Name),
            nameof(CurrencyView.Description),
        };
    }
}
