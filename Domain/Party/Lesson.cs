using App.Data.Party;
namespace App.Domain.Party
{
    public class Lesson: Entity<LessonData>
    {
        private const string defaultStr = "Undefined";
        private DateTime defaultDate = DateTime.MinValue;

        public Lesson(): this(new LessonData()){}
        public Lesson(LessonData d): base(d){}

        public string Id => Data?.Id ?? defaultStr;
        public string Instructor => Data?.Instructor?? defaultStr;
        public string Student => Data?.Student ?? defaultStr;
        public string LessonName => Data?.LessonName ?? defaultStr;
        public DateTime LessonTime => Data?.LessonTime ?? defaultDate;
        public string Location => Data?.Location ?? defaultStr;
        public string EquipmentNeeded => Data?.EquipmentNeeded ?? defaultStr;
        public override string ToString() => $"{Instructor} {Student} {LessonName} {LessonTime}";
    }
}
