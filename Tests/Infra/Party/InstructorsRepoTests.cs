using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using App.Infra;
using App.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Infra.Party
{
    [TestClass]
    public class InstructorsRepoTests : SealedRepoTests<InstructorsRepo, Repo<Instructor, InstructorData>, Instructor, InstructorData>
    {
        protected override InstructorsRepo createObj() => new(GetRepo.Instance<AppDB>());
        protected override object? getSet(AppDB db) => db.Instructors;
    }
}
