using App.Data.Party;
using App.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Domain;

[TestClass]
public class NamedEntityTests : AbstractClassTests {
    private class testClass: NamedEntity<CountryData> { }
    protected override object createObj() => new testClass();
}