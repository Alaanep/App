
using App.Data.Party;

namespace App.Domain.Party
{
    public class Lesson
    {
        private const string defaultStr = "Undefined";
        private DateTime defaultDate = DateTime.MinValue;

        private LessonData data;
        public Lesson(): this(new LessonData()){}
        public Lesson(LessonData d) => data = d;

        public string Id => data?.Id ?? defaultStr;
        public string Instructor => data?.Instructor?? defaultStr;
        public string Student => data?.Student ?? defaultStr;
        public string LessonName => data?.LessonName ?? defaultStr;
        public DateTime LessonTime => data?.LessonTime ?? defaultDate;
        public string Location => data?.Location ?? defaultStr;
        public string EquipmentNeeded => data?.EquipmentNeeded ?? defaultStr;
        public override string ToString() => $"{Instructor} {Student} {LessonName} {LessonTime}";
        public LessonData Data => data;
    }
}
