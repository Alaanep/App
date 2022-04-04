using App.Domain.Party;
using App.Facade.Party;
namespace App.Pages.Party
{
    public class InstructorsPage: PagedPage<InstructorView, Instructor, IInstructorsRepo> 
    {
        public InstructorsPage(IInstructorsRepo r): base(r){}
        protected override Instructor toObject(InstructorView? item) => new InstructorViewFactory().Create(item);
        protected override InstructorView toView(Instructor? entity) => new InstructorViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(InstructorView.FirstName),
            nameof(InstructorView.LastName),
            nameof(InstructorView.PhoneNr),
            nameof(InstructorView.LessonsGiven),
        };
    }
}
