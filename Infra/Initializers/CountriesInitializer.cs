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
                if (l.FirstOrDefault(x => x.Id == id) is not null) continue;
                if (string.IsNullOrWhiteSpace(country.ThreeLetterISORegionName)) continue;
                var data = createCountry(country.ThreeLetterISORegionName, country.EnglishName, country.NativeName);
                l.Add(data);
            }
            return l;
        }
    }

    internal static CountryData createCountry(string code, string name, string description) 
        => new () 
        {
            Id = code??EntityData.NewId, 
            Code = code??Entity.DefaultStr, 
            Name = name, Description = description
        };
}