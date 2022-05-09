using App.Domain.Party;
using App.Facade.Party;
using App.Pages;
using App.Pages.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Pages.Party {
    [TestClass]
    public class StudentsPageTests : SealedBaseTests<StudentsPage, PagedPage<StudentView, Student, IStudentsRepo>> {
        protected override StudentsPage createObj() => new StudentsPage(null);
    }
}
