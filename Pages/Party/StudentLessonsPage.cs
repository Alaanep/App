using App.Domain.Party;
using App.Facade.Party;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Pages.Party
{
    public sealed class StudentLessonsPage : PagedPage<StudentLessonView, StudentLesson, IStudentLessonsRepo>
    {
        private readonly IStudentsRepo students;
        private readonly ILessonsRepo lessons;

        public StudentLessonsPage(IStudentLessonsRepo r, IStudentsRepo stu, ILessonsRepo les) : base(r)
        {
            students = stu;
            lessons = les;
        }
        protected override StudentLesson toObject(StudentLessonView? item) => new StudentLessonViewFactory().Create(item);
        protected override StudentLessonView toView(StudentLesson? entity) => new StudentLessonViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(StudentLessonView.StudentId),
            nameof(StudentLessonView.LessonId),
        };

        public IEnumerable<SelectListItem> Students
            => students?.GetAll(x => x.ToString())?
                   .Select(x => new SelectListItem(x.ToString(), x.Id))
               ?? new List<SelectListItem>();

        public IEnumerable<SelectListItem> Lessons
            => lessons?.GetAll(x => x.ToString())?
                   .Select(x => new SelectListItem(x.ToString(), x.Id))
               ?? new List<SelectListItem>();

        public string StudentName(string? studentId = null)
            => Students?.FirstOrDefault(x => x.Value == (studentId ?? string.Empty))?.Text ?? "Unspecified";

        public string LessonName(string? lessonId = null)
            => Lessons?.FirstOrDefault(x => x.Value == (lessonId ?? string.Empty))?.Text ?? "Unspecified";

        public override object? GetValue(string name, StudentLessonView v)
        {
            var result = base.GetValue(name, v);
            return name == nameof(StudentLessonView.StudentId) ? StudentName(result as string)
                : name == nameof(StudentLessonView.LessonId) ? LessonName(result as string)
                : result;
        }
    }
}
