using App.Data.Party;

namespace App.Domain.Party
{
    public interface ICurrencyRepo : IRepo<Currency> { }
    public sealed class Currency : NamedEntity<CurrencyData> {
        public Currency() : this(new CurrencyData()) { }
        public Currency(CurrencyData d) : base(d) { }
        public string Symbol => getValue(Data?.Symbol);
    }
}
