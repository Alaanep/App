using App.Aids;
using App.Data.Party;
using App.Domain;
using App.Domain.Party;
using App.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Infra
{
    [TestClass] public class OrderedRepoTests : AbstractClassTests<OrderedRepo<Instructor, InstructorData>, FilteredRepo<Instructor, InstructorData>>
    {
        private class testClass : OrderedRepo<Instructor, InstructorData>
        {
            public testClass(DbContext? c, DbSet<InstructorData>? s) : base(c, s) { }
            protected internal override Instructor toDomain(InstructorData d) => new(d);
        }
        protected override OrderedRepo<Instructor, InstructorData> createObj() {
            var db = GetRepo.Instance<AppDB>();
            var set = db?.Instructors;
            return new testClass(db, set);
        }
        [TestMethod] public void CurrentOrderTest() => isProperty<string>();
        [TestMethod] public void DescendingStringTest() => areEqual("_desc", testClass.DescendingString);
        [DataRow(null, true)]
        [DataRow(null, false)]
        [DataRow(nameof(Instructor.Id), true)]
        [DataRow(nameof(Instructor.Id), false)]
        [DataRow(nameof(Instructor.FirstName), true)]
        [DataRow(nameof(Instructor.FirstName), false)]
        [DataRow(nameof(Instructor.LastName), true)]
        [DataRow(nameof(Instructor.LastName), false)]
        [DataRow(nameof(Instructor.PhoneNr), true)]
        [DataRow(nameof(Instructor.PhoneNr), false)]
        [DataRow(nameof(Instructor.LessonsGiven), true)]
        [DataRow(nameof(Instructor.LessonsGiven), false)]
        [TestMethod] public void CreateSqlTest(string s, bool isDescending ) {
            obj.CurrentOrder = (s is null) ? s : isDescending ? s + testClass.DescendingString : s;
            var q = obj.createSql();
            var actual = q.Expression.ToString();
            if (s is null) isTrue(actual.EndsWith(".Select(s => s)"));
            else if (isDescending) isTrue(actual.EndsWith(
                $".Select(s => s).OrderByDescending(x => Convert(x.{s}, Object))"));
            else isTrue(actual.EndsWith(
                $".Select(s => s).OrderBy(x => Convert(x.{s}, Object))"));
        }
        [DataRow(true, true)]
        [DataRow(false, true)]
        [DataRow(true, false)]
        [DataRow(false, false)]
        [TestMethod] public void SortOrderTest(bool isDescending, bool isSame) {
            var s = GetRandom.String();
            var c = isSame ? s : GetRandom.String();
            obj.CurrentOrder = isDescending ? c + testClass.DescendingString : c;
            var actual = obj.SortOrder(s);
            var sDes = s + testClass.DescendingString;
            var expected = isSame ? (isDescending ? s : sDes) : sDes;
            areEqual(expected, actual);
        }
    }
}

