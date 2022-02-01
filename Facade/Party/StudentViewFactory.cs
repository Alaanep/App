
using App.Data.Party;
using App.Domain.Party;

namespace App.Facade.Party
{
    public class StudentViewFactory
    {
        public Student Create(StudentView v) => new Student(new StudentData
        {
            Id = v.Id,
            FirstName = v.FirstName,
            LastName = v.LastName,
            PhoneNr = v.PhoneNr,
            Height = v.Height,
            Weight = v.Weight,
            ShoeSize = v.ShoeSize,
            EnrollmentDate = v.EnrollmentDate,
            Level = v.Level
        });
         

        public StudentView Create(Student student)  => new StudentView
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            PhoneNr = student.PhoneNr,
            Height = student.Height,
            Weight = student.Weight,
            ShoeSize = student.ShoeSize,
            EnrollmentDate = student.EnrollmentDate,
            Level = student.Level
        };
    }
}
