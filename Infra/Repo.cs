using App.Data;
using App.Domain;
using Microsoft.EntityFrameworkCore;

namespace App.Infra {
    // todo To protect from overposting attacks, enable the specific properties you want to bind to, for
    // todo more details, see https://aka.ms/RazorPagesCRUD.
    // todo To protect from overposting attacks, enable the specific properties you want to bind to, for
    // todo more details, see https://aka.ms/RazorPagesCRUD.
    public abstract class Repo<TDomain, TData> : PagedRepo<TDomain, TData>
        where TDomain : UniqueEntity<TData>, new() where TData : UniqueData, new()
    {
        protected Repo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
    }
}
