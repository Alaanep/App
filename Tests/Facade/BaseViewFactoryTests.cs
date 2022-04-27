using App.Aids;
using App.Data.Party;
using App.Domain.Party;
using App.Facade;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade {
    [TestClass] public class BaseViewFactoryTests : AbstractClassTests<BaseViewFactory<InstructorView, Instructor, InstructorData>, object> {
        private class testClass: BaseViewFactory<InstructorView, Instructor, InstructorData> {
            protected override Instructor toEntity(InstructorData d) => new(d);
        }
        protected override BaseViewFactory<InstructorView, Instructor, InstructorData> createObj() => new testClass();
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest()
        {
            var v = GetRandom.Value<InstructorView>();
            var o = obj.Create(v);
            arePropertiesEqual(v, o.Data);
        }
        [TestMethod] public void CreateObjectTest()
        {
            var d = GetRandom.Value<InstructorData>();
            var v = obj.Create(new Instructor(d));
            arePropertiesEqual(d, v);
        }
    }
}
