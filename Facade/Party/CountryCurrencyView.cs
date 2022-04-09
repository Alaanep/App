using App.Data.Party;
using App.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Facade.Party
{
    public class CountryCurrencyView : NamedView
    {
        [DisplayName("Country")][Required] public string? CountryId { get; set; }
        [DisplayName("Currency")][Required] public string? CurrencyId { get; set; }
        [DisplayName("Currency native name")] public new string? Name { get; set; }
        [DisplayName("Currency code")] public new string? Code { get; set; }
    }
    public sealed class CountryCurrencyViewFactory : BaseViewFactory<CountryCurrencyView, CountryCurrency, CountryCurrencyData> {
        protected override CountryCurrency toEntity(CountryCurrencyData d) => new(d);
    }
}
