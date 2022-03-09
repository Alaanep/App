using App.Data.Party;
using App.Domain.Party;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Party
{
    public class LessonsRepo: Repo<Lesson, LessonData>, ILessonsRepo
    {
        public LessonsRepo(AppDB? db) : base(db, db?.Lessons) { }
        protected override Lesson toDomain(LessonData d) => new(d);
    }
}