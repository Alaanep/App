using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using App.Data;
using App.Data.Party;
using App.Domain.Party;
using App.Facade.Party;
using App.Infra.Party;
using Microsoft.EntityFrameworkCore;


namespace App.Pages.Lessons
{
    public class LessonsPage: PageModel
    {
        private readonly ILessonsRepo repo;
        [BindProperty] public LessonView Lesson { get; set; }
        public LessonsPage(ApplicationDbContext c) => repo = new LessonsRepo(c, c.Lessons);
        public IActionResult OnGetCreate()=>Page();
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)return Page();
            await repo.AddAsync(new LessonViewFactory().Create(Lesson));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Lesson = await getLesson(id);
            return Lesson == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Lesson = await getLesson(id);
            return Lesson == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null)return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Lesson = await getLesson(id);
            return Lesson == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)return Page();
            var obj = new LessonViewFactory().Create(Lesson);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public IList<LessonView> Lessons { get; set; }
        public async Task<IActionResult> OnGetIndexAsync()
        {
            var list = await repo.GetAsync();
            Lessons = new List<LessonView>();
            foreach (var obj in list)
            {
                var l = new LessonViewFactory().Create(obj);
                Lessons.Add(l);
            }
            return Page();
        }
        private async Task<LessonView> getLesson(string id) => new LessonViewFactory().Create(await repo.GetAsync(id));
        
    }
}
