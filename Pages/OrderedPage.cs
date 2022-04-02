using App.Domain;
using App.Facade;

namespace App.Pages;

public abstract class OrderedPage<TView, TEntity, TRepo> : FilteredPage<TView, TEntity, TRepo>
    where TView : UniqueView
    where TEntity : UniqueEntity
    where TRepo : IOrderedRepo<TEntity> {
    protected OrderedPage(TRepo r) : base(r) { }
    public string? CurrentSort {
        get => repo.CurrentSort;
        set => repo.CurrentSort = value;
    }
    public string? SortOrder(string propertyName) => repo.SortOrder(propertyName);
}