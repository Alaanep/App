using App.Data.Party;

namespace App.Domain.Party
{
    public sealed class Currency : Entity<CurrencyData> {
        public Currency() : this(new CurrencyData()) { }
        public Currency(CurrencyData d) : base(d) { }
        public string Code => getValue(Data?.Code);
        public string Symbol => getValue(Data?.Symbol);
        public string EnglishName => getValue(Data?.EnglishName);
        public string NativeName => getValue(Data?.NativeName);
    }
}
