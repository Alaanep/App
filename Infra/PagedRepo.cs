using App.Data;
using App.Domain;
using Microsoft.EntityFrameworkCore;

namespace App.Infra
{
    public abstract class PagedRepo<TDomain, TData> : OrderedRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new()
    {
        protected PagedRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
    }
}
