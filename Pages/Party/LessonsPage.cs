using App.Domain.Party;
using App.Facade.Party;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Pages.Party
{
    public class LessonsPage: PagedPage<LessonView, Lesson, ILessonsRepo>
    {
        private IStudentsRepo students;

        public LessonsPage(ILessonsRepo r, IStudentsRepo s) : base(r) {
            students = s;
        }
        protected override Lesson toObject(LessonView? item) => new LessonViewFactory().Create(item);
        protected override LessonView toView(Lesson? entity) => new LessonViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(LessonView.Instructor),
            nameof(LessonView.Student),
            nameof(LessonView.LessonName),
            nameof(LessonView.LessonTime),
            nameof(LessonView.Location),
            nameof(LessonView.EquipmentNeeded),
        };

        public IEnumerable<SelectListItem> Students
            => students?.GetAll(x => x.FirstName)?
                   .Select(x => new SelectListItem(x.FirstName, x.Id))
               ?? new List<SelectListItem>();

        public string StudentName(string? countryId = null)
            => Students?.FirstOrDefault(x => x.Value == countryId)?.Text ?? "Unspecified";

        public override object? GetValue(string name, LessonView v) {
            var result = base.GetValue(name, v);
            if (name == nameof(LessonView.Student)) return StudentName(result as string);
            return result;
        }
    }
}
