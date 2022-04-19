using App.Data.Party;
using App.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Domain;

[TestClass]
public class UniqueEntityTests : AbstractClassTests<UniqueEntity<CountryData>, UniqueEntity> {
    private class testClass : UniqueEntity<CountryData> { }
    protected override UniqueEntity<CountryData> createObj() => new testClass();
    [TestMethod] public void DataTest() => isInconclusive();
    [TestMethod] public void IdTest() => isReadOnly(obj.Data.Id);
    [TestMethod] public void DefaultStrTest() => areEqual(testClass.DefaultStr, "Undefined");
}