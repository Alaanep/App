using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using App.Data;
using App.Data.Party;
using App.Domain.Party;
using App.Facade.Party;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace App.Pages.Lessons;

public class LessonsPage: PageModel
{
    //todo To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    //todo To protect from overposting attacks, enable the specific properties you want to bind to.
    //todo For more details, see https://aka.ms/RazorPagesCRUD.
    private readonly ApplicationDbContext context;
    [BindProperty] public LessonView BindData { get; set; }
    public LessonsPage(ApplicationDbContext c) => context = c;

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

        var d = new LessonViewFactory().Create(BindData).Data;
        context.Lessons.Add(d);
        await context.SaveChangesAsync();

        return RedirectToPage("./Index", "Index");
    }

    private async Task<LessonView> getLesson(string id)
    {
        if (id == null) return null;
        var d = await context.Lessons.FirstOrDefaultAsync(m => m.Id == id);
        if (d == null) return null;
        return new LessonViewFactory().Create(new Lesson(d));
    }

    public async Task<IActionResult> OnGetDetailsAsync(string id)
    {
        BindData = await getLesson(id);
        return BindData == null ? NotFound() : Page();
    }

    public async Task<IActionResult> OnGetDeleteAsync(string id)
    {
        BindData = await getLesson(id);
        return BindData == null ? NotFound() : Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var d = await context.Lessons.FindAsync(id);

        if (d != null)
        {
            context.Lessons.Remove(d);
            await context.SaveChangesAsync();
        }

        return RedirectToPage("./Index", "Index");
    }

    public async Task<IActionResult> OnGetEditAsync(string id)
    {
        BindData = await getLesson(id);
        return BindData == null ? NotFound() : Page();
    }

    public async Task<IActionResult> OnPostEditAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var d = new LessonViewFactory().Create(BindData).Data;
        context.Attach(d).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LessonDataExists(BindData.Id))
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

    private bool LessonDataExists(string id)
    {
        return context.Lessons.Any(e => e.Id == id);
    }


    public IList<LessonView> Lessons { get; set; }

    public async Task OnGetIndexAsync()
    {

        var list = await context.Lessons.ToListAsync();
        Lessons = new List<LessonView>();
        foreach (var d in list)
        {
            var l = new LessonViewFactory().Create(new Lesson(d));
            Lessons.Add(l);
        }
    }
}