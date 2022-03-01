using App.Data.Party;
using App.Domain.Party;

namespace App.Facade.Party;

public class InstructorViewFactory
{
    public Instructor Create(InstructorView v) => new Instructor(new InstructorData 
    {
        Id = v.Id,
        FirstName = v.FirstName,
        LastName = v.LastName,
        PhoneNr = v.PhoneNr,
        LessonsGiven = v.LessonsGiven
    });
    public InstructorView Create(Instructor i) => new InstructorView 
    {
        Id = i.Id,
        FirstName = i.FirstName,
        LastName = i.LastName,
        PhoneNr = i.PhoneNr,
        LessonsGiven = i.LessonsGiven,
        FullName=i.ToString()
    };
}