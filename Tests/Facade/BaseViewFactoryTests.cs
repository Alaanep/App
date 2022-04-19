using App.Data.Party;
using App.Domain.Party;
using App.Facade;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade {
    [TestClass]
    public class BaseViewFactoryTests : AbstractClassTests<BaseViewFactory<InstructorView, Instructor, InstructorData>, object> {
        private class testClass: BaseViewFactory<InstructorView, Instructor, InstructorData> {
            protected override Instructor toEntity(InstructorData d) => new(d);
        }
        protected override BaseViewFactory<InstructorView, Instructor, InstructorData> createObj() => new testClass();
    }
}
