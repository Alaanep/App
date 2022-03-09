using App.Domain.Party;
using System.ComponentModel;
using App.Data.Party;

namespace App.Facade.Party {
    public sealed class LessonView: BaseView {
        [DisplayName("Instructor")]public  string? Instructor { get; set; }
        [DisplayName("Student")] public string? Student { get; set; }
        [DisplayName("Lesson: ")] public string? LessonName { get; set; }
        [DisplayName("Lesson Time")] public DateTime? LessonTime { get; set; }
        [DisplayName("Location")] public string? Location { get; set; }
        [DisplayName("Equipment needed: ")] public string? EquipmentNeeded { get; set; }
        [DisplayName("Lesson")] public string? FullName { get; set; }
    }
    public sealed class LessonViewFactory : BaseViewFactory<LessonView, Lesson, LessonData> {
        protected override Lesson toEntity(LessonData d) => new(d);
        public override LessonView Create(Lesson? e) {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
}
