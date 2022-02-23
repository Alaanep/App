using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using App.Data;
using App.Domain.Party;
using App.Facade.Party;
using App.Infra.Party;
using Microsoft.EntityFrameworkCore;

namespace App.Pages.Students
{
    //todo To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    //todo To protect from overposting attacks, enable the specific properties you want to bind to.
    //todo For more details, see https://aka.ms/RazorPagesCRUD.
    public class StudentsPage : PageModel
    {
        private readonly IStudentsRepo repo;
        private readonly ApplicationDbContext context;
        [BindProperty] public StudentView Student { get; set; }
        public IList<StudentView> Students { get; set; }
        public StudentsPage(ApplicationDbContext c) => repo = new StudentsRepo(c, c.Students);
        public IActionResult OnGetCreate()=>Page();
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(new StudentViewFactory().Create(Student));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Student = await getStudent(id);
            return Student == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Student = await getStudent(id);
            return Student == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null)return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Student = await getStudent(id);
            return Student == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            var obj = new StudentViewFactory().Create(Student);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetIndexAsync()
        {
            var list = await repo.GetAsync();
            Students = new List<StudentView>();
            foreach (var obj in list)
            {
                var v = new StudentViewFactory().Create(obj);
                Students.Add(v);
            }
            return Page();
        }
        private async Task<StudentView> getStudent(string id)=> new StudentViewFactory().Create(await repo.GetAsync(id));
    }
}
