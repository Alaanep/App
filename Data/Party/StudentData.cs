using System.ComponentModel.DataAnnotations;
namespace App.Data.Party {
    public sealed class StudentData: EntityData {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNr { get; set; }
        public string? Email { get; set; }
        public string? Weight { get; set; }
        public string? Height { get; set; }
        public string? ShoeSize { get; set; }
        [DataType(DataType.Date)] public DateTime? EnrollmentDate { get; set; }
        public string? Level { get; set; }
    }
}
