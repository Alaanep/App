using App.Data.Party;

namespace App.Domain.Party
{
    public sealed class StudentLesson : UniqueEntity<StudentLessonData>
    {
        public StudentLesson() : this(new()) { }
        public StudentLesson(StudentLessonData d) : base(d) { }
        public string StudentId => getValue(Data?.StudentId);
        public string LessonId => getValue(Data?.LessonId);
        public Student? Student => GetRepo.Instance<IStudentsRepo>()?.Get(StudentId);
        public Lesson? Lesson => GetRepo.Instance<ILessonsRepo>()?.Get(LessonId);
    }
}
