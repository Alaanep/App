using App.Domain.Party;
using App.Facade.Party;

namespace App.Pages.Party
{
    public class LessonsPage: PagedPage<LessonView, Lesson, ILessonsRepo>
    {
        public LessonsPage(ILessonsRepo r) : base(r){}
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
    }
}
