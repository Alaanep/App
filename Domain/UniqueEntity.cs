using App.Data;
using App.Data.Party;

namespace App.Domain
{
    public abstract class UniqueEntity {
        public static string DefaultStr => "Undefined";
        protected const bool defaultBool = false;
        protected static DateTime defaultDate => DateTime.MinValue;
        protected static string getValue(string? v) => v ?? DefaultStr;
        protected static bool getValue(bool? v) => v ?? defaultBool;
        protected static DateTime getValue(DateTime? v) => v ?? defaultDate;
        protected static Level getValue(Level? l) => l ?? Level.NotKnown;
    }
    public abstract class UniqueEntity<TData> : UniqueEntity where TData : UniqueData, new() {
        public TData Data { get; }
        public UniqueEntity() : this(new TData()) {}
        public UniqueEntity(TData d) => Data = d;
        public string Id => getValue(Data?.Id);
    }
}