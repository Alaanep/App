using App.Data.Party;
using App.Domain.Party;

namespace App.Infra.Party
{
    public sealed class StudentLessonsRepo : Repo<StudentLesson, StudentLessonData>, IStudentLessonsRepo
    {
        public StudentLessonsRepo(AppDB? db) : base(db, db?.StudentLessons) { }
        protected internal override StudentLesson toDomain(StudentLessonData d) => new(d);

        internal override IQueryable<StudentLessonData> addFilter(IQueryable<StudentLessonData> q)
        {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)
                ? q : q.Where(
                    x => x.Id.Contains(y)
                         || x.StudentId.Contains(y)
                         || x.LessonId.Contains(y));
        }
    }
}
