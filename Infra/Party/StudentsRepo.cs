using App.Data.Party;
using App.Domain.Party;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Party
{
    public class StudentsRepo: Repo<Student, StudentData>, IStudentsRepo
    {
        public StudentsRepo(AppDB? db): base(db,db?.Students){}

        protected override Student toDomain(StudentData d) => new(d);
    }
}
