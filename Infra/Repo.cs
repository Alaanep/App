using App.Data;
using App.Domain;
using Microsoft.EntityFrameworkCore;

namespace App.Infra {
    
    public abstract class Repo<TDomain, TData> : PagedRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new() {
        protected Repo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
    }
}
