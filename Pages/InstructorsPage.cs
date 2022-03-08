using App.Domain.Party;
using App.Facade.Party;
namespace App.Pages
{
    public class InstructorsPage: BasePage<InstructorView, Instructor, IInstructorsRepo> 
    {
        public InstructorsPage(IInstructorsRepo r): base(r){}
        protected override Instructor toObject(InstructorView item) => new InstructorViewFactory().Create(item);
        protected override InstructorView toView(Instructor entity) => new InstructorViewFactory().Create(entity);
    }
}
