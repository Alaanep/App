using App.Data.Party;

namespace App.Domain.Party {
    public class Instructor: Entity<InstructorData> {
        public Instructor() : this(new InstructorData()) { }
        public Instructor(InstructorData d) : base(d) { }
        public string FirstName => Data?.FirstName ?? defaultStr;
        public string LastName => Data?.LastName ?? defaultStr;
        public string PhoneNr => Data?.PhoneNr ?? defaultStr;
        public string LessonsGiven => Data?.LessonsGiven ?? defaultStr;
        public override string ToString() => $"{FirstName} {LastName}";
    }
}
