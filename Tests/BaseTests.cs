using System;
using App.Aids;
using System.Diagnostics;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Domain;

namespace App.Tests;
public abstract class BaseTests<TClass, TBaseClass> : TypeTests where TClass : class where TBaseClass : class {
    protected TClass obj;
    protected BaseTests() => obj = createObj();
    protected abstract TClass createObj();

    protected void isProperty<T>(T? value = default, bool isReadOnly = false, string? callingMethod = null) {
        callingMethod ??= nameof(isProperty);
        var actual = getProperty(ref value, isReadOnly, callingMethod);
        areEqual(value, actual);
    }
    protected object? getProperty<T>(ref T? value, bool isReadOnly, string callingMethod)
    {
        var memberName = getCallingMember(callingMethod).Replace("Test", string.Empty);
        var propertyInfo = obj.GetType().GetProperty(memberName);
        isNotNull(propertyInfo);
        if (isNullOrDefault(value)) value = random<T>();
        if (!canWrite(propertyInfo, isReadOnly)) propertyInfo.SetValue(obj, value);
        propertyInfo.SetValue(obj, value);
        return propertyInfo.GetValue(obj);
    }
    protected void isReadOnly<T>(T? value) => isProperty(value, true, nameof(isReadOnly));
    protected object? isReadOnly<T>(string? callingMethod = null) {
        var def = default(T);
        return getProperty(ref def, true, callingMethod ?? nameof(isReadOnly));
    }
    protected void itemTest<TRepo, TObj, TData>(string id, Func<TData, TObj> toObj, Func<TObj?> getObj)
    where TRepo : class, IRepo<TObj> where TObj : UniqueEntity
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
    private static bool isNullOrDefault<T>(T? value) => value?.Equals(default(T)) ?? true;//kas T tüüp on oma vaikeväärtusega võrdne

    private static bool canWrite(PropertyInfo i, bool isReadOnly) {
        var canWrite = i?.CanWrite??false;
        areEqual(canWrite, !isReadOnly);
        return canWrite;
    }
    private static T? random<T>() => GetRandom.Value<T>();

    private static string getCallingMember(string memberName) {
        var s = new StackTrace();
        var isNext = false;
        for (var i = 0; i < s.FrameCount - 1; i++) {
            var n = s.GetFrame(i)?.GetMethod()?.Name ?? string.Empty;
            if(n is "MoveNext" or "Start") continue;
            if (isNext) return n;
            if (n == memberName) isNext = true;
        }
        return string.Empty;
    }

    protected internal static void arePropertiesEqual(object x, object y) {
        var e = Array.Empty<PropertyInfo>();
        var px = x?.GetType().GetProperties() ?? e;
        var hasProperties = false;
        foreach (var prop in px) {
            var a = prop.GetValue(x, null);
            var py = y?.GetType().GetProperty(prop.Name);
            if (py == null) continue;
            var b = py.GetValue(y, null);
            areEqual(a, b);
            hasProperties = true;
        }
        isTrue(hasProperties, $"No properties found for {x}");
    }

    [TestMethod] public void BaseClassTest() => areEqual(typeof(TClass).BaseType, typeof(TBaseClass));

}