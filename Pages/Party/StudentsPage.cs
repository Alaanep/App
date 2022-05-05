using App.Aids;
using App.Data.Party;
using App.Domain.Party;
using App.Facade.Party;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Pages.Party {
    //todo To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    //todo To protect from overposting attacks, enable the specific properties you want to bind to.
    //todo For more details, see https://aka.ms/RazorPagesCRUD.
    [Authorize]
    public class StudentsPage : PagedPage<StudentView, Student, IStudentsRepo>
    {
        public StudentsPage(IStudentsRepo r) : base(r) { }
        protected override Student toObject(StudentView? item) => new StudentViewFactory().Create(item);
        protected override StudentView toView(Student? entity) => new StudentViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(StudentView.FirstName),
            nameof(StudentView.LastName),
            nameof(StudentView.PhoneNr),
            nameof(StudentView.Email),
            nameof(StudentView.Weight),
            nameof(StudentView.Height),
            nameof(StudentView.ShoeSize),
            nameof(StudentView.EnrollmentDate),
            nameof(StudentView.Level),
        };

        public IEnumerable<SelectListItem> Levels
            => Enum.GetValues<Level>()?
                   .Select(x => new SelectListItem(x.Description(), x.ToString()))
               ?? new List<SelectListItem>();

        public string LevelDescription(Level? level)
            => (level ?? Level.NotKnown).Description();

        public override object? GetValue(string name, StudentView v) {
            var result = base.GetValue(name, v);
            return name == nameof(StudentView.Level) ? LevelDescription((Level)result) : result;
        }


    }
}