﻿using App.Domain;
using App.Facade;
using Microsoft.AspNetCore.Mvc;

namespace App.Pages;

public abstract class PagedPage<TView, TEntity, TRepo> : OrderedPage<TView, TEntity, TRepo>
    where TView : UniqueView
    where TEntity : UniqueEntity
    where TRepo : IPagedRepo<TEntity> {
    protected PagedPage(TRepo r) : base(r) { }

    public int PageIndex {
        get => repo.PageIndex;
        set => repo.PageIndex = value;
    }
    public int TotalPages => repo.TotalPages;
    public bool HasNextPage => repo.HasNextPage;
    public bool HasPreviousPage => repo.HasPreviousPage;
    protected override void setAttributes(int pageIndex, string? currentFilter, string? sortOrder) {
        PageIndex = pageIndex;
        CurrentFilter = currentFilter;
        CurrentSort = sortOrder;
    }
    protected override IActionResult redirectToIndex()
        => RedirectToPage("./Index", "Index", new {
            pageIndex = PageIndex,
            currentFilter = CurrentFilter,
            sortOrder = CurrentSort
        });
}