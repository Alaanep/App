using App.Domain.Party;
using App.Facade.Party;

namespace App.Pages.Party {
    //todo To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    //todo To protect from overposting attacks, enable the specific properties you want to bind to.
    //todo For more details, see https://aka.ms/RazorPagesCRUD.
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
    }
}