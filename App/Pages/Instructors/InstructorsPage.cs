using App.Data;
using App.Domain.Party;
using App.Facade.Party;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace App.Pages.Instructors;

// TODO: To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see https://aka.ms/RazorPagesCRUD.
public class InstructorsPage:PageModel 
{
    private readonly ApplicationDbContext context;
    [BindProperty] public InstructorView BindData { get; set; }
    public IList<InstructorView> Instructors { get; set; }
    public InstructorsPage(ApplicationDbContext c) => context = c;
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
        var d = new InstructorViewFactory().Create(BindData).Data;

        context.Instructors.Add(d);
        await context.SaveChangesAsync();

        return RedirectToPage("./Index","Index");
    }
    public async Task<IActionResult> OnGetDetailsAsync(string id)
    {
        BindData = await getInstructor(id);
        return BindData == null? NotFound() : Page();
    }
    private async Task<InstructorView> getInstructor(string id)
    {
        if (id == null) return null;
        var d = await context.Instructors.FirstOrDefaultAsync(m => m.Id == id);
        if (d == null)return null;
        return new InstructorViewFactory().Create(new Instructor(d));
    }
    public async Task<IActionResult> OnGetDeleteAsync(string id)
    {
        BindData = await getInstructor(id);
        return BindData == null ? NotFound() : Page();
    }
    public async Task<IActionResult> OnPostDeleteAsync(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var d = await context.Instructors.FindAsync(id);

        if (d != null)
        {
            context.Instructors.Remove(d);
            await context.SaveChangesAsync();
        }

        return RedirectToPage("./Index","Index");
    }
    public async Task<IActionResult> OnGetEditAsync(string id)
    {
        BindData = await getInstructor(id);
        return BindData == null ? NotFound() : Page();
    }
    public async Task<IActionResult> OnPostEditAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var d = new InstructorViewFactory().Create(BindData).Data;
        context.Attach(d).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!InstructorExists(BindData.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index","Index");
    }
    private bool InstructorExists(string id) 
        => context.Instructors.Any(e => e.Id == id);
    public async Task OnGetIndexAsync()
    {
        var list = await context.Instructors.ToListAsync();
        Instructors = new List<InstructorView>();
        foreach (var d in list)
        {
            var v = new InstructorViewFactory().Create(new Instructor(d));
            Instructors.Add(v);
        }
    }
}