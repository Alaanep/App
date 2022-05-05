using System.ComponentModel.DataAnnotations;

namespace App.Data
{
    public abstract class UniqueData {
        protected static byte[] empty => Array.Empty<byte>();
        public static string NewId => Guid.NewGuid().ToString();
        public string Id { get; set; } = NewId;
        [Timestamp] public byte[] Token { get; set; } = empty;
    }
}
