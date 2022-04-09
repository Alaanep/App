using App.Data.Party;

namespace App.Infra.Initializers {
    public sealed class LessonsInitializer : BaseInitializer<LessonData> {

        public LessonsInitializer(AppDB? db) : base(db, db?.Lessons) { }

        protected override IEnumerable<LessonData> getEntities => new LessonData[] {
            createLesson("Toomas Toob", "Malle Kask", Level.B1, new DateTime(2022, 05,05), "Stroomi rand", "Komplekt1"),
            createLesson("Madis Viib", "Helle Hell", Level.B2, new DateTime(2022, 06,06), "Stroomi rand", "Komplekt2"),
            createLesson("Maru Vahva", "Tauno Vaher", Level.B3, new DateTime(2022, 07,07), "Stroomi rand", "Komplekt3")
        };

        internal static LessonData createLesson(string instructor, string student, Level lessonName, DateTime lessonTime, string location, string equipmentNeeded) {
            var lesson = new LessonData() {
                Id = Guid.NewGuid().ToString(),
                Instructor = instructor,
                Student = student,
                LessonName = lessonName,
                LessonTime = lessonTime,
                Location = location,
                EquipmentNeeded = equipmentNeeded
            };
            return lesson;
        }
    }
}
