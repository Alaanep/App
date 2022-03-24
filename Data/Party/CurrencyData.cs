

namespace App.Data.Party
{
    public sealed class CurrencyData : EntityData {
        public string Code { get; set; }
        public string? Symbol { get; set; }
        public string? EnglishName { get; set; }
        public string? NativeName { get; set; }
    }
}
