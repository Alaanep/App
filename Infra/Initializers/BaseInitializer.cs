using App.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Initializers;

public abstract class BaseInitializer<TData> where TData: UniqueData {
    protected internal DbContext? database;
    protected internal DbSet<TData>? dbSet;

    protected BaseInitializer(DbContext? c, DbSet<TData>? s) {
        database = c;
        dbSet = s;
    }

    public void Init() {
        if(dbSet?.Any()?? true) return;
        dbSet.AddRange(getEntities);
        database?.SaveChanges();
    }

    protected abstract IEnumerable<TData> getEntities{ get; }
    internal static bool isCorrectIsoCode(string id) => string.IsNullOrWhiteSpace(id) ? false : char.IsLetter(id[0]);

}
