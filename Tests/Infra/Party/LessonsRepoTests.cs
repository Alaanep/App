using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using App.Infra;
using App.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Infra.Party
{
    [TestClass]
    public class LessonsRepoTests : SealedRepoTests<LessonsRepo, Repo<Lesson, LessonData>, Lesson, LessonData>
    {
        protected override LessonsRepo createObj() => new(GetRepo.Instance<AppDB>());
        protected override object? getSet(AppDB db) => db.Lessons;
    }
}
