using App.Data.Party;
using App.Domain.Party;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Party {
    public sealed class InstructorsRepo: Repo<Instructor, InstructorData>, IInstructorsRepo {
        public InstructorsRepo(AppDB? db) : base(db, db?.Instructors) { }
        protected override Instructor toDomain(InstructorData d) => new(d);
        internal override IQueryable<InstructorData> addFilter(IQueryable<InstructorData> q) {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
                x => x.Id.Contains(y)
                     || x.FirstName.Contains(y)
                     || x.LastName.Contains(y)
                     || x.PhoneNr.Contains(y)
                     || x.LessonsGiven.Contains(y));
        }
    }
}
