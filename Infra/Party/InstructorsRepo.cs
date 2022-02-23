using App.Data.Party;
using App.Domain.Party;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Party
{
    public class InstructorsRepo: Repo<Instructor, InstructorData>, IInstructorsRepo
    {
        public InstructorsRepo(DbContext c, DbSet<InstructorData> s) : base(c, s) { }
        protected override Instructor toDomain(InstructorData d) => new Instructor(d);
    }
}
