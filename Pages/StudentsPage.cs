using App.Domain.Party;
using App.Facade.Party;
using App.Infra.Party;
using Microsoft.AspNetCore.Mvc;

namespace App.Pages
{
    //todo To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    //todo To protect from overposting attacks, enable the specific properties you want to bind to.
    //todo For more details, see https://aka.ms/RazorPagesCRUD.
    public class StudentsPage : BasePage<StudentView, Student, IStudentsRepo>
    {
        public StudentsPage(IStudentsRepo r) : base(r) { }
        protected override Student toObject(StudentView? item) => new StudentViewFactory().Create(item);
        protected override StudentView toView(Student? entity) => new StudentViewFactory().Create(entity);
    }
}