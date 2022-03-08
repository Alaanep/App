using App.Data.Party;
namespace App.Domain.Party {
    public class Lesson: Entity<LessonData> {
        public Lesson(): this(new LessonData()){}
        public Lesson(LessonData d): base(d){}
        public string Instructor => Data?.Instructor?? defaultStr;
        public string Student => Data?.Student ?? defaultStr;
        public string LessonName => Data?.LessonName ?? defaultStr;
        public DateTime LessonTime => Data?.LessonTime ?? defaultDate;
        public string Location => Data?.Location ?? defaultStr;
        public string EquipmentNeeded => Data?.EquipmentNeeded ?? defaultStr;
        public override string ToString() => $"{Instructor} {Student} {LessonName} {LessonTime}";
    }
}
