using App.Data.Party;
using App.Domain.Party;
using System.ComponentModel;


namespace App.Facade.Party
{
    public sealed class CurrencyView : IsoNamedView {
        [DisplayName("Symbol")] public string? Symbol { get; set; }
    }
    public sealed class CurrencyViewFactory : BaseViewFactory<CurrencyView, Currency, CurrencyData> {
        protected override Currency toEntity(CurrencyData d) => new(d);
    }
}
