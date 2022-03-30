using App.Domain;
using App.Facade;

namespace App.Pages;

public abstract class CrudPage<TView, TEntity, TRepo> : BasePage<TView, TEntity, TRepo>
    where TView : UniqueView
    where TEntity : UniqueEntity
    where TRepo : ICrudRepo<TEntity> {
    protected CrudPage(TRepo r) : base(r) {}
}