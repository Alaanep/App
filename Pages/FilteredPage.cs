using App.Domain;
using App.Facade;

namespace App.Pages;

public abstract class FilteredPage<TView, TEntity, TRepo> : CrudPage<TView, TEntity, TRepo>
    where TView : UniqueView
    where TEntity : UniqueEntity
    where TRepo : IFilteredRepo<TEntity> {
    protected FilteredPage(TRepo r) : base(r) { }
}