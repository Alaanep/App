using App.Data.Party;
using App.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Domain;

[TestClass]
public class UniqueEntityTests : AbstractClassTests {
    private class testClass : UniqueEntity<CountryData> { }
    protected override object createObj() => new testClass();

}