using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using App.Data.Party;
using App.Domain.Party;

namespace App.Facade.Party {
    public sealed class StudentView: UniqueView {
        [DisplayName("First Name")]public string? FirstName { get; set; }
        [DisplayName("Last Name")]public string? LastName { get; set; }
        [DisplayName("Phone nr")]public string? PhoneNr { get; set; }
        [DisplayName("Email")] public string? Email { get; set; }
        [DisplayName("Weight")]public string? Weight { get; set; }
        [DisplayName("Height")]public string? Height { get; set; }
        [DisplayName("Shoe Size")]public string? ShoeSize { get; set; }
        //[DataType(DataType.Date)]
        [DisplayName("Enrollment Date")]public DateTime? EnrollmentDate { get; set; }
        [DisplayName("Level")]public Level? Level { get; set; }
        [DisplayName("Full Name")]public string? FullName { get; set; }
    }
    public sealed class StudentViewFactory : BaseViewFactory<StudentView, Student, StudentData> {
        protected override Student toEntity(StudentData d) => new(d);

        public override Student Create(StudentView? v) {
            v ??= new StudentView();
            v.Level ??= Level.NotKnown;
            return base.Create(v);
        }

        public override StudentView Create(Student? e) {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            v.Level=e?.Level;
            return v;
        }
    }
}
