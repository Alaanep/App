using App.Aids;
using App.Data;
using App.Domain;
using App.Domain.Party;
using App.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace App.Tests;

public abstract class HostTests : TestAsserts {
    internal static readonly TestHost<Program> host;
    internal static readonly HttpClient client;
    [TestInitialize]
    public virtual void TestInitialize()
    {
        (GetRepo.Instance<ICountryRepo>() as CountryRepo)?.clear();
        (GetRepo.Instance<ICurrencyRepo>() as CurrencyRepo)?.clear();
        (GetRepo.Instance<ICountryCurrenciesRepo>() as CountryCurrenciesRepo)?.clear();
    }
    static HostTests() 
    {
        host = new TestHost<Program>();
        client = host.CreateClient();
    }
    protected virtual object? isReadOnly<T>(string? callingMethod = null) => null;
    protected virtual void arePropertiesEqual(object? x, object? y) { }

    protected void itemTest<TRepo, TObj, TData>(string id, Func<TData, TObj> toObj, Func<TObj?> getObj)
        where TRepo : class, IRepo<TObj>
        where TObj : UniqueEntity
    {
        var c = isReadOnly<TObj>(nameof(itemTest));
        isNotNull(c);
        isInstanceOfType(c, typeof(TObj));
        var r = GetRepo.Instance<TRepo>();
        var d = GetRandom.Value<TData>();
        d.Id = id;
        var cnt = GetRandom.Int32(5, 30);
        var idx = GetRandom.Int32(0, cnt);
        for (var i = 0; i < cnt; i++)
        {
            var x = (i == idx) ? d : GetRandom.Value<TData>();
            isNotNull(x);
            r?.Add(toObj(x));
        }
        r.PageSize = 30;
        areEqual(cnt, r.Get().Count);
        areEqualProperties(d, getObj());
    }
    protected void itemsTest<TRepo, TObj, TData>(Action<TData> setId, Func<TData, TObj> toObj, Func<List<TObj>> getList)
        where TRepo : class, IRepo<TObj>
        where TObj : UniqueEntity<TData>
        where TData : UniqueData, new() {

        var o = isReadOnly<List<TObj>>(nameof(itemsTest));
        isNotNull(o);
        isInstanceOfType(o, typeof(List<TObj>));
        var r = GetRepo.Instance<TRepo>();
        isNotNull(r);
        var list = new List<TData>();
        var cnt = GetRandom.Int32(5, 30);
        for (var i = 0; i < cnt; i++)
        {
            var x = GetRandom.Value<TData>();
            if (GetRandom.Bool())
            {
                setId(x);
                list.Add(x);
            }
            r.Add(toObj(x));
        }
        r.PageSize = 30;
        areEqual(cnt, r.Get().Count);
        var l = getList();
        areEqual(list.Count, l.Count);
        foreach (var data in list)
        {
            var y = l.Find(z => z.Id == data.Id); //otsib l-st suvalist objekti z nii, et z ID = selles listis oleva järjekordse elemendi Id-ga. Kui leiab, siis z=y
            isNotNull(y);
            areEqualProperties(data, y);
        }
    }
    protected void relatedItemsTest<TRepo, TRelatedItem, TItem, TData>(Action relatedTest,
    Func<List<TRelatedItem>> relatedItems, Func<List<TItem?>> items,
    Func<TRelatedItem, string> detailId,
    Func<TData, TItem> toObj, Func<TItem?, TData?> toData, Func<TRelatedItem?, TData?> relatedToData)
    where TRepo : class, IRepo<TItem>
    where TItem : UniqueEntity
    where TRelatedItem : UniqueEntity
    {
        relatedTest();
        var list = relatedItems();
        var r = GetRepo.Instance<TRepo>();
        foreach (var e in list)
        {
            var x = GetRandom.Value<TData>();
            if (x is not null) x.Id = detailId(e);
            r?.Add(toObj(x));
        }
        var currencies = items();
        areEqual(list.Count, currencies.Count);
        foreach (var e in list)
        {
            var a = currencies.Find(x => x?.Id == detailId(e));
            arePropertiesEqual(toData(a), relatedToData(e));
        }
    }
}