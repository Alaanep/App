using App.Aids;
using App.Data.Party;
using App.Domain.Party;
using App.Facade;
using App.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Facade.Party {
    [TestClass] public class LessonViewFactoryTests
        : ViewFactoryTests<LessonViewFactory, LessonView, Lesson, LessonData>
    {
        protected override Lesson toObject(LessonData d) => new(d);
    }
}
