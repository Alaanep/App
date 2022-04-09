using App.Data.Party;

namespace App.Domain.Party {
    public interface IInstructorsRepo : IRepo<Instructor> { }

    public class Instructor: UniqueEntity<InstructorData> {
        public Instructor() : this(new ()) { }
        public Instructor(InstructorData d) : base(d) { }
        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public string PhoneNr => getValue(Data?.PhoneNr);
        public string LessonsGiven => getValue(Data?.LessonsGiven);
        public override string ToString() => $"{FirstName} {LastName}";
    }
}
