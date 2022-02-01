using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace App.Facade.Party
{
    public class StudentView
    {
        [Required] public string Id { get; set; }
        [DisplayName("First Name")]public string? FirstName { get; set; }
        [DisplayName("Last Name")]public string? LastName { get; set; }
        [DisplayName("Phone nr")]public string? PhoneNr { get; set; }
        [DisplayName("Weight")]public string? Weight { get; set; }
        [DisplayName("Height")]public string? Height { get; set; }
        [DisplayName("Shoe Size")]public string? ShoeSize { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Enrollment Date")]public DateTime? EnrollmentDate { get; set; }
        [DisplayName("Level")]public string? Level { get; set; }
        [DisplayName("Full Name")]public string? FullName { get; set; }
    }
}
