﻿using App.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Data.Party {
    [TestClass]
    public class CountryDataTests: SealedClassTests<CountryData> {
        [TestMethod] public void NameTest() => isProperty<string>();
        [TestMethod] public void CodeTest() => isProperty<string>();
        [TestMethod] public void DescriptionTest() => isProperty<string>();
    }
}
