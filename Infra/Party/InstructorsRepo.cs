using App.Data.Party;
using App.Domain.Party;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Party
{
    public class InstructorsRepo: Repo<Instructor, InstructorData>, IInstructorsRepo
    {
        public InstructorsRepo(AppDB? db) : base(db, db?.Instructors) { }
        protected override Instructor toDomain(InstructorData d) => new(d);
    }
}
