

using System.Runtime.CompilerServices;
using App.Data.Party;

namespace App.Domain.Party
{
    public class Student
    {
        private const string defaultStr = "Undefined";
        private DateTime defaultDate = DateTime.MinValue;

        private StudentData data;
        public Student(): this(new StudentData()){ }
        public Student(StudentData d) => data = d;

        public string Id => data?.Id ?? defaultStr;
        public string FirstName => data?.FirstName ?? defaultStr;
        public string LastName => data?.LastName ?? defaultStr;
        public string PhoneNr => data?.PhoneNr?? defaultStr;
        public string Email => data?.Email?? defaultStr;
        public string Weight => data?.Weight ?? defaultStr;
        public string Height => data?.Height ?? defaultStr;
        public string ShoeSize => data?.ShoeSize ?? defaultStr;
        public DateTime EnrollmentDate => data?.EnrollmentDate ?? defaultDate;
        public string Level => data?.Level?? defaultStr;
        public override string ToString() => $"{FirstName} {LastName}";
        public StudentData Data => data;
    }
}
