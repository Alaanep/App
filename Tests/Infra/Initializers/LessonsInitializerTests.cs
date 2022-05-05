using App.Data.Party;
using App.Domain;
using App.Infra;
using App.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Infra.Initializers
{
    [TestClass] public class LessonsInitializerTests
        : SealedBaseTests<LessonsInitializer, BaseInitializer<LessonData>>
    {
        protected override LessonsInitializer createObj()
        {
            var db = GetRepo.Instance<AppDB>();
            return new LessonsInitializer(db);
        }
    }
}
