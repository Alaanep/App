using App.Data.Party;
using App.Domain.Party;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Facade.Party
{
    public sealed class StudentLessonView : UniqueView
    {
        [DisplayName("Student")][Required] public string? StudentId { get; set; }
        [DisplayName("Lesson")][Required] public string? LessonId { get; set; }
    }
    public sealed class StudentLessonViewFactory : BaseViewFactory<StudentLessonView, StudentLesson, StudentLessonData>
    {
        protected override StudentLesson toEntity(StudentLessonData d) => new(d);
    }
}
