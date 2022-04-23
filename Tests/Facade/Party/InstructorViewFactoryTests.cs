using App.Aids;
using App.Data.Party;
using App.Domain.Party;
using App.Facade;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party {
    [TestClass] public class InstructorViewFactoryTests
        : ViewFactoryTests<InstructorViewFactory, InstructorView, Instructor, InstructorData>
    {
        protected override Instructor toObject(InstructorData d) => new(d);
    }
}
