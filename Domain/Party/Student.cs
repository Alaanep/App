using App.Data.Party;
namespace App.Domain.Party {
    public sealed class Student: UniqueEntity<StudentData> {
        public Student(): this(new ()){ }
        public Student(StudentData d): base(d){}
        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public string PhoneNr => getValue(Data?.PhoneNr);
        public string Email => getValue(Data?.Email);
        public string Weight => getValue(Data?.Weight);
        public string Height => getValue(Data?.Height);
        public string ShoeSize => getValue(Data?.ShoeSize);
        public DateTime EnrollmentDate => getValue(Data?.EnrollmentDate);
        public Level Level => getValue(Data?.Level);
        public override string ToString() => $"{FirstName} {LastName}";
        public Lazy<List<StudentLesson>> StudentLessons
        {
            get
            {
                var l = GetRepo.Instance<IStudentLessonsRepo>()?
                       .GetAll(x => x.StudentId)?
                       .Where(x => x.StudentId == Id)?
                       .ToList() ?? new List<StudentLesson>();
                return new Lazy<List<StudentLesson>>(l);
            }
        }
        public Lazy<List<Lesson?>> Lessons
        {
            get
            {
                var l = StudentLessons.Value
                    .Select(x => x.Lesson)?
                    .ToList() ?? new List<Lesson?>();
                return new Lazy<List<Lesson?>>(l);
            }
        }

        public int CompareTo(object? x) => compareTo(x as Student);

        private int compareTo(Student? c) => Id.CompareTo(c?.Id);
    }
}

