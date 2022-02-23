﻿using App.Data;
namespace App.Domain
{
    public abstract class Entity {}
    public abstract class Entity<TData> : Entity where TData : EntityData, new()
    {
        public TData Data => data;
        private readonly TData data;
        public Entity() : this(new TData()) {}
        public Entity(TData d) => data = d;
    }
}