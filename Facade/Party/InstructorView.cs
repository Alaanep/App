using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Facade.Party;

public class InstructorView
{
    [Required] public string Id { get; set; }
    [DisplayName("First name")] [Required] public string? FirstName { get; set; }
    [DisplayName("Last name")] [Required] public string? LastName { get; set; }
    [DisplayName("Phone nr")] public string? PhoneNr { get; set; }
    [DisplayName("Lessons given")] public string? LessonsGiven { get; set; }
    [DisplayName("Full name")] public string? FullName { get; set; }
}