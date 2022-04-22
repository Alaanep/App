using System;
using App.Domain;
using App.Domain.Party;
using App.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Domain;

[TestClass] public class GetRepoTests : TypeTests {

    private class testClass : IServiceProvider {
        public object? GetService(Type serviceType) {
            throw new NotImplementedException();
        }
    }
    [TestMethod] public void InstanceTest() => Assert.IsInstanceOfType(GetRepo.Instance<ICountryRepo>(), typeof(CountryRepo));
    [TestMethod] public  void SetServiceTest() {
        var s = GetRepo.service;
        var x = new testClass();
        GetRepo.SetService(x);
        areEqual(x, GetRepo.service);
        GetRepo.service = s;
    }
}