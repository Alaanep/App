using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using App.Data.Party;
using App.Domain.Party;

namespace App.Facade.Party
{
    public sealed class InstructorView: UniqueView {
        [DisplayName("First name")] [Required] public string? FirstName { get; set; }
        [DisplayName("Last name")] [Required] public string? LastName { get; set; }
        [DisplayName("Phone nr")] public string? PhoneNr { get; set; }
        [DisplayName("Lessons given")] public string? LessonsGiven { get; set; }
        [DisplayName("Full name")] public string? FullName { get; set; }
    }
    public sealed class InstructorViewFactory : BaseViewFactory<InstructorView, Instructor, InstructorData> {
        protected override Instructor toEntity(InstructorData d) => new(d);
        public override InstructorView Create(Instructor? e) {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            return v;
        }
    }
}
