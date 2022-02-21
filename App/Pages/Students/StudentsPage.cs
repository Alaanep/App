#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using App.Data;
using App.Domain.Party;
using App.Facade.Party;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace App.Pages.Students
{
    //todo To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    //todo To protect from overposting attacks, enable the specific properties you want to bind to.
    //todo For more details, see https://aka.ms/RazorPagesCRUD.
    public class StudentsPage : PageModel
    {
        private readonly ApplicationDbContext context;

        [BindProperty]
        public StudentView BindData { get; set; }
        public IList<StudentView> Students { get; set; }
        public StudentsPage(ApplicationDbContext c) => context = c;
        
        public IActionResult OnGetCreate()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new StudentViewFactory().Create(BindData).Data;
            context.Students.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index", "Index");
        }

        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            BindData = await getStudent(id);
            return BindData == null ? NotFound() : Page();
        }

        private async Task<StudentView> getStudent(string id)
        {
            if (id == null)return null;
            var d = await context.Students.FirstOrDefaultAsync(m => m.Id == id);
            if (d == null)return null;
            return new StudentViewFactory().Create(new Student(d));
        }

        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            BindData = await getStudent(id);
            return BindData == null ? NotFound() : Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await context.Students.FindAsync(id);


            if (d != null)
            {
                context.Students.Remove(d);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", "Index");
        }

        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            BindData = await getStudent(id);
            return BindData == null ? NotFound() : Page();
        }

        
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new StudentViewFactory().Create(BindData).Data;
            context.Attach(d).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!studentExists(BindData.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", "Index");
        }

        private bool studentExists(string id) => context.Students.Any(e => e.Id == id);

        

        public async Task OnGetIndexAsync()
        {
            var list = await context.Students.ToListAsync();
            Students = new List<StudentView>();
            foreach (var d in list)
            {
                var v = new StudentViewFactory().Create(new Student(d));
                Students.Add(v);
            }
        }

    }
}
