using App.Data.Party;
using App.Domain.Party;
using System.ComponentModel;


namespace App.Facade.Party
{
    public sealed class CurrencyView : BaseView {
        [DisplayName("Code")] public string? Code { get; set; }
        [DisplayName("Symbol")] public string? Symbol { get; set; }
        [DisplayName("English Name")] public string? EnglishName { get; set; }
        [DisplayName("Native Name")] public string? NativeName { get; set; }
    }
    public sealed class CurrencyViewFactory : BaseViewFactory<CurrencyView, Currency, CurrencyData> {
        protected override Currency toEntity(CurrencyData d) => new(d);
    }
}
