using App.Data.Party;
using App.Domain.Party;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Party {
    public sealed class StudentsRepo: Repo<Student, StudentData>, IStudentsRepo {
        public StudentsRepo(AppDB? db): base(db,db?.Students){}
        protected internal override Student toDomain(StudentData d) => new(d);
        internal override IQueryable<StudentData> addFilter(IQueryable<StudentData> q) {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
                x => x.Id.Contains(y)
                     || x.FirstName.Contains(y)
                     || x.LastName.Contains(y)
                     || x.PhoneNr.Contains(y)
                     || x.Email.Contains(y)
                     || x.Weight.Contains(y)
                     || x.Height.Contains(y)
                     || x.ShoeSize.Contains(y)
                     || x.Level.ToString().Contains(y)
                     || x.EnrollmentDate.ToString().Contains(y));
        }
    }
}
