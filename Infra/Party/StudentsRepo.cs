using App.Data.Party;
using App.Domain.Party;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Party {
    public class StudentsRepo: Repo<Student, StudentData>, IStudentsRepo {
        public StudentsRepo(AppDB? db): base(db,db?.Students){}
        protected override Student toDomain(StudentData d) => new(d);
        internal override IQueryable<StudentData> addFilter(IQueryable<StudentData> q) {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
                x => contains(x.Id, y)
                || contains(x.FirstName, y)
                || contains(x.LastName, y)
                || contains(x.PhoneNr, y)
                || contains(x.Email, y)
                || contains(x.Weight, y)
                || contains(x.Height, y)
                || contains(x.ShoeSize, y)
                || contains(x.EnrollmentDate.ToString(), y)
                || contains(x.Level, y));
        }
    }
}
