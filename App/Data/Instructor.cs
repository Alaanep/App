using System.ComponentModel.DataAnnotations;

namespace App.Data
{
    public class Instructor
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNr { get; set; }
        public string? LessonsGiven { get; set; }
    }
}
