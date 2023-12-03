using forthekittens_razor.Data;
using forthekittens_razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace forthekittens_razor.Pages.Categories
{
    public class createModel : PageModel
    {
        private readonly Kittensdbcontext_razor _db;
        public createModel(Kittensdbcontext_razor db)
        {
            _db = db;
        }
        [BindProperty]
        public Category category { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Category obj) 
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToPage("/categories/index");
        }
    }
}
