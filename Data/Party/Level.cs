using System.ComponentModel;

namespace App.Data.Party {
    public enum Level {
        [Description("B1")] B1 = 1,
        [Description("B2")] B2 = 2,
        [Description("B3")] B3 = 3,
        [Description("Refresher")] Refresher = 4,
        [Description("Snowkite")] Snowkite = 5,
        [Description("Not Known")] NotKnown = 6
    }
}
