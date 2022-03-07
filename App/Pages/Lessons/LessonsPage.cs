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
        [BindProperty] public LessonView Item { get; set; }
        public IList<LessonView> Items { get; set; }
        public string ItemId => Item?.Id ?? string.Empty;
        public LessonsPage(AppDB c) => repo = new LessonsRepo(c, c.Lessons);
        public IActionResult OnGetCreate()=>Page();
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)return Page();
            await repo.AddAsync(new LessonViewFactory().Create(Item));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Item = await getLesson(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Item = await getLesson(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null)return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Item = await getLesson(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)return Page();
            var obj = new LessonViewFactory().Create(Item);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        
        public async Task<IActionResult> OnGetIndexAsync()
        {
            var list = await repo.GetAsync();
            Items = new List<LessonView>();
            foreach (var obj in list)
            {
                var l = new LessonViewFactory().Create(obj);
                Items.Add(l);
            }
            return Page();
        }
        private async Task<LessonView> getLesson(string id) => new LessonViewFactory().Create(await repo.GetAsync(id));
        
    }
}
