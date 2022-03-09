﻿using App.Aids;
using System.Diagnostics;
using System.Reflection;

namespace App.Tests;

public abstract class BaseTests: IsTypeTested {
    protected object obj;
    protected BaseTests() => obj = createObj();

    protected abstract object createObj();

    protected void isProperty<T>(T? value = default, bool isReadOnly = false)
    {
        var memberName = getCallingMember(nameof(isProperty)).Replace("Test", string.Empty);
        var propertyInfo = obj.GetType().GetProperty(memberName);
        isNotNull(propertyInfo);
        if (isNullOrDefault(value)) value = random<T>();
        if (!canWrite(propertyInfo, isReadOnly)) return;
        propertyInfo.SetValue(obj, value);
        areEqual(value, propertyInfo.GetValue(obj));

    }

    private static bool isNullOrDefault<T>(T? value) => value?.Equals(default(T)) ?? true;//kas T tüüp on oma vaikeväärtusega võrdne

    private static bool canWrite(PropertyInfo i, bool isReadOnly)
    {
        var canWrite = i?.CanWrite??false;
        areEqual(canWrite, !isReadOnly);
        return canWrite;
    }
    private static T random<T>() => GetRandom.Value<T>();

    private static string getCallingMember(string memberName)
    {
        var s = new StackTrace();
        var isNext = false;
        for (var i = 0; i < s.FrameCount - 1; i++)
        {
            var n = s.GetFrame(i)?.GetMethod()?.Name ?? string.Empty;
            if(n is "MoveNext" or "Start") continue;
            if (isNext) return n;
            if (n == memberName) isNext = true;
        }

        return string.Empty;
    }

}