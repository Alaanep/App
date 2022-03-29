using App.Data;
using App.Domain;
using Microsoft.EntityFrameworkCore;

namespace App.Infra
{
    public abstract class FilteredRepo<TDomain, TData> : CrudRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new()
    {
        protected FilteredRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
    }
}
