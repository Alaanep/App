using App.Data.Party;
using System.Globalization;

namespace App.Infra.Initializers
{
    public sealed class CurrenciesInitializer : BaseInitializer<CurrencyData>
    {
        public CurrenciesInitializer(AppDB? db) : base(db, db?.Currencies) { }

        protected override IEnumerable<CurrencyData> getEntities
        {
            get
            {
                var l = new List<CurrencyData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                {
                    var currency = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var data = createCurrency(currency.ISOCurrencySymbol, currency.CurrencySymbol, currency.CurrencyEnglishName, currency.CurrencyNativeName);
                    if (l.FirstOrDefault(x => x.Id == data.Id) is not null) continue;
                    l.Add(data);
                }
                return l;
            }
        }
        internal static CurrencyData createCurrency(string code, string symbol, string englishName, string nativeName) => new () { 
            Id = code, Code = code, Symbol = symbol,  EnglishName = englishName, NativeName = nativeName };
    }
}
