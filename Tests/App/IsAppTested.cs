﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.App
{
    [TestClass]
    public class IsAppTested:IsAssemblyTested
    {
        protected override void isAllTested() => inconclusive("Namespace has to be changed to \"App.App\"");
    }
}