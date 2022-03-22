using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Aids;

namespace App.Tests;

public abstract class TestAsserts
{
    protected static void isInconclusive(string? s = null) => Assert.Inconclusive(s ?? string.Empty);
    protected static void isNotNull([NotNull] object? o = null, string? message = null) => Assert.IsNotNull(o, message);
    protected static void areEqual(object? expected, object? actual, string? message = null) => Assert.AreEqual(expected, actual, message);
    protected static void areNotEqual(object? expected, object? actual, string? message = null) => Assert.AreNotEqual(expected, actual, message);
    protected static void isInstanceOfType(object o, Type expectedType, string? message = null) => Assert.IsInstanceOfType(o, expectedType, message);
    protected static void isTrue(bool? b, string? message = null) => Assert.IsTrue(b ?? false, message ?? string.Empty);
    protected static void isFalse(bool? b, string? message = null) => Assert.IsTrue(b ?? true, message ?? string.Empty);
    protected static void arePropertiesEqual(object? expected, object? actual, string? exceptPropName=null,  string? message = null) {
        long changes = 0;
        foreach (var expectedProp in expected?.GetType()?.GetProperties() ?? Array.Empty<PropertyInfo>()){
            var actualProp = actual?.GetType()?.GetProperty(expectedProp.Name);
            if (actualProp != null) {
                if (!expectedProp.GetValue(expected).Equals(actualProp.GetValue(actual)))changes++;
            }
            else {
                if(exceptPropName == null) {
                    changes++;
                    break;
                }
                if (!expectedProp.Name.Contains(exceptPropName))changes++;
            }
        }
        isTrue(changes == 0);
    }
}