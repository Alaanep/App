using App.Data.Party;
using App.Domain.Party;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Party
{
    public class LessonsRepo: Repo<Lesson, LessonData>, ILessonsRepo
    {
        public LessonsRepo(DbContext c, DbSet<LessonData> s) : base(c, s) { }
        protected override Lesson toDomain(LessonData d) => new Lesson(d);
    }
}