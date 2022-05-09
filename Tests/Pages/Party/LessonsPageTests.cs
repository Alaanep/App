using App.Domain.Party;
using App.Facade.Party;
using App.Pages;
using App.Pages.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Pages.Party {
    [TestClass]
    public class LessonsPageTests : SealedBaseTests<LessonsPage, PagedPage<LessonView, Lesson, ILessonsRepo>> {
        protected override LessonsPage createObj() => new LessonsPage(null, null);
    }
}
