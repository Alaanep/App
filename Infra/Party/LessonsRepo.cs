using App.Data.Party;
using App.Domain.Party;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Party
{
    public class LessonsRepo: Repo<Lesson, LessonData>, ILessonsRepo
    {
        public LessonsRepo(AppDB? db) : base(db, db?.Lessons) { }
        protected override Lesson toDomain(LessonData d) => new(d);
        internal override IQueryable<LessonData> addFilter(IQueryable<LessonData> q)
        {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
                x => x.Id.Contains(y)
                || x.Instructor.Contains(y)
                || x.Student.Contains(y)
                || x.LessonName.Contains(y)
                || x.LessonTime.ToString().Contains(y)
                || x.Location.Contains(y)
                || x.EquipmentNeeded.Contains(y));
        }
    }
}