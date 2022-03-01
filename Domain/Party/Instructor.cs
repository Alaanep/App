using App.Data.Party;

namespace App.Domain.Party;

public class Instructor
{
    private const string defaultStr = "Undefined";

    private InstructorData data;
    public Instructor() : this(new InstructorData()) { }
    public Instructor(InstructorData d) => data = d;

    public string Id => data?.Id ?? defaultStr;
    public string FirstName => data?.FirstName ?? defaultStr;
    public string LastName => data?.LastName ?? defaultStr;
    public string PhoneNr => data?.PhoneNr ?? defaultStr;
    public string LessonsGiven => data?.LessonsGiven ?? defaultStr;

    public override string ToString() => $"{FirstName} {LastName}";
    public InstructorData Data => data;
}