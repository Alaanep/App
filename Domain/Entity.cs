﻿using App.Data;
namespace App.Domain {
    public abstract class Entity {
        public static string DefaultStr => "Undefined";
        protected const bool defaultBool = false;
        protected static DateTime defaultDate => DateTime.MinValue;
        protected static string getValue(string? v) => v ?? DefaultStr;
        protected static bool getValue(bool? v) => v ?? defaultBool;
        protected static DateTime getValue(DateTime? v) => v ?? defaultDate;
    }
    public abstract class Entity<TData> : Entity where TData : EntityData, new() {
        public TData Data => data;
        private readonly TData data;
        public Entity() : this(new TData()) {}
        public Entity(TData d) => data = d;
        public string Id => getValue(Data?.Id);
    }
}