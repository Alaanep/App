using App.Domain;
using App.Domain.Party;
using App.Facade.Party;
using App.Pages;
using App.Pages.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Pages.Party {
    [TestClass]
    public class InstructorsPageTests : SealedBaseTests<InstructorsPage, PagedPage<InstructorView, Instructor, IInstructorsRepo>> {
        private InstructorsPage? page;
        protected override InstructorsPage createObj() => page = new InstructorsPage(GetRepo.Instance<IInstructorsRepo>());

        [TestMethod]
        public void IndexColumnsTest() {
            var arr = new string[] { "FirstName", "LastName", "PhoneNr", "LessonsGiven" };
            for (var i = 0; i < arr.Length; i++) {
                areEqual(arr[i], page?.IndexColumns[i]);
            }
        }
    }
}
