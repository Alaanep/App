using App.Domain.Party;
using App.Facade.Party;
using App.Pages;
using App.Pages.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Pages.Party {
    [TestClass]
    public class InstructorsPageTests : SealedBaseTests<InstructorsPage, PagedPage<InstructorView, Instructor, IInstructorsRepo>> {
        protected override InstructorsPage createObj() => new InstructorsPage(null);
    }
}
