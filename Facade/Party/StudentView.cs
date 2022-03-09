using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ABC.Facade.Party;
using App.Data.Party;
using App.Domain.Party;

namespace App.Facade.Party {
    public class StudentView: BaseView {
        [DisplayName("First Name")]public string? FirstName { get; set; }
        [DisplayName("Last Name")]public string? LastName { get; set; }
        [DisplayName("Phone nr")]public string? PhoneNr { get; set; }
        [DisplayName("Email")] public string? Email { get; set; }
        [DisplayName("Weight")]public string? Weight { get; set; }
        [DisplayName("Height")]public string? Height { get; set; }
        [DisplayName("Shoe Size")]public string? ShoeSize { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Enrollment Date")]public DateTime? EnrollmentDate { get; set; }
        [DisplayName("Level")]public string? Level { get; set; }
        [DisplayName("Full Name")]public string? FullName { get; set; }
    }
    public sealed class StudentViewFactory : BaseViewFactory<StudentView, Student, StudentData> {
        protected override Student toEntity(StudentData d) => new(d);
    }
}
