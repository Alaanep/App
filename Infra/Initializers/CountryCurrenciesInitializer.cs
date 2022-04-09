using System.Globalization;
using App.Data;
using App.Data.Party;
using App.Domain;

namespace App.Infra.Initializers;

public sealed class CountryCurrenciesInitializer : BaseInitializer<CountryCurrencyData>
{
    public CountryCurrenciesInitializer(AppDB? db) : base(db, db?.CountryCurrencies) { }

    protected override IEnumerable<CountryCurrencyData> getEntities
    {
        get
        {
            var l = new List<CountryCurrencyData>();
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                var cc = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                var countryId = cc.ThreeLetterISORegionName;
                var currencyId = cc.ISOCurrencySymbol;
                var nativeName = cc.CurrencyNativeName;
                var currencyCode = cc.CurrencySymbol;
                var d = createEntity(countryId, currencyId, currencyCode, nativeName);
                l.Add(d);
            }
            return l;
        }
    }
    internal static CountryCurrencyData createEntity(string? countryId, string? currencyId, string? code, string? name = null, string? description =null)
        => new()
        {
            Id = UniqueData.NewId,
            Code = code ?? UniqueEntity.DefaultStr,
            Name = name,
            CountryId = countryId,
            CurrencyId = currencyId,
            Description=description
        };
}
