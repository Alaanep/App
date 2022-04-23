using App.Aids;
using App.Data.Party;
using App.Domain.Party;
using App.Facade;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party {
    [TestClass] public class StudentViewFactoryTests
        : ViewFactoryTests<StudentViewFactory, StudentView, Student, StudentData>
    {
        protected override Student toObject(StudentData d) => new(d);
    }
}
