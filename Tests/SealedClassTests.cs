﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests;

public abstract class SealedClassTests<TClass, TBaseClass>
    : BaseTests<TClass, TBaseClass> where TClass : class, new() where TBaseClass : class {
    protected override TClass createObj() => new();

    [TestMethod] public void IsSealedTest() => isTrue(obj?.GetType()?.IsSealed ?? false);

}