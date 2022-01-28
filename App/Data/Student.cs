using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations;

namespace App.Data
{
    public class Student
    {

        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNr { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public int? ShoeSize { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }
        public string? Level { get; set; }


}
}
