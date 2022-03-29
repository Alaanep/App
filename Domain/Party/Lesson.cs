using App.Data.Party;
namespace App.Domain.Party {
    public interface ILessonsRepo : IRepo<Lesson> { }

    public class Lesson: UniqueEntity<LessonData> {
        public Lesson(): this(new LessonData()){}
        public Lesson(LessonData d): base(d){}
        public string Instructor => getValue(Data?.Instructor);
        public string Student => getValue(Data?.Student);
        public string LessonName => getValue(Data?.LessonName);
        public DateTime LessonTime => getValue(Data?.LessonTime);
        public string Location => getValue(Data?.Location);
        public string EquipmentNeeded => getValue(Data?.EquipmentNeeded);
        public override string ToString() => $"{Instructor} {Student} {LessonName} {LessonTime}";
    }
}
