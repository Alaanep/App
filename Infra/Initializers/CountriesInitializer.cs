using System.Globalization;
using App.Data;
using App.Data.Party;
using App.Domain;

namespace App.Infra.Initializers;

public sealed class CountriesInitializer : BaseInitializer<CountryData> {
    public CountriesInitializer(AppDB? db) : base(db, db?.Countries) { }

    protected override IEnumerable<CountryData> getEntities {
        get
        {
            var l = new List<CountryData>();
            foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                var country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                var id = country.ThreeLetterISORegionName;
                if (!isCorrectIsoCode(id)) continue;
                if (l.FirstOrDefault(x => x.Id == id) is not null) continue;
                var data = createCountry(country.ThreeLetterISORegionName, country.EnglishName, country.NativeName);
                l.Add(data);
            }
            return l;
        }
    }
    internal static CountryData createCountry(string code, string englishName, string nativeName) 
        => new () 
        {
            Id = code??UniqueData.NewId, 
            Code = code??UniqueEntity.DefaultStr, 
            Name = englishName, Description = nativeName
        };
}