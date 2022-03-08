using App.Data.Party;
namespace App.Domain.Party {
    public class Student: Entity<StudentData> {
        public Student(): this(new StudentData()){ }
        public Student(StudentData d): base(d){}
        public string FirstName => Data?.FirstName ?? defaultStr;
        public string LastName => Data?.LastName ?? defaultStr;
        public string PhoneNr => Data?.PhoneNr?? defaultStr;
        public string Email => Data?.Email?? defaultStr;
        public string Weight => Data?.Weight ?? defaultStr;
        public string Height => Data?.Height ?? defaultStr;
        public string ShoeSize => Data?.ShoeSize ?? defaultStr;
        public DateTime EnrollmentDate => Data?.EnrollmentDate ?? defaultDate;
        public string Level => Data?.Level?? defaultStr;
        public override string ToString() => $"{FirstName} {LastName}";
    }
}
