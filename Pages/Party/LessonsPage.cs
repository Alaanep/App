using App.Domain.Party;
using App.Facade.Party;

namespace App.Pages.Party
{
    public class LessonsPage: PagedPage<LessonView, Lesson, ILessonsRepo>
    {
        public LessonsPage(ILessonsRepo r) : base(r){}
        protected override Lesson toObject(LessonView? item) => new LessonViewFactory().Create(item);
        protected override LessonView toView(Lesson? entity) => new LessonViewFactory().Create(entity);
    }
}
