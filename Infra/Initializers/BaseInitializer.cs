using App.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Initializers;

public abstract class BaseInitializer<TData> where TData: EntityData {
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
}

public static class AppInitializer {
    public static void Init(AppDB appDb) {
        new InstructorsInitializer(appDb).Init();
        new LessonsInitializer(appDb).Init();
        new StudentsInitializer(appDb).Init();
        new CountriesInitializer(appDb).Init();
        new CurrenciesInitializer(appDb).Init();
    }
}