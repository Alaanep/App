using App.Data.Party;
using App.Domain.Party;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Party {
    public class InstructorsRepo: Repo<Instructor, InstructorData>, IInstructorsRepo {
        public InstructorsRepo(AppDB? db) : base(db, db?.Instructors) { }
        protected override Instructor toDomain(InstructorData d) => new(d);
        internal override IQueryable<InstructorData> addFilter(IQueryable<InstructorData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q
                : q.Where(
                    x => contains(x.Id, y)
                         || contains(x.FirstName, y)
                         || contains(x.LastName, y)
                         || contains(x.PhoneNr, y)
                         || contains(x.LessonsGiven, y));
        }
    }
}
