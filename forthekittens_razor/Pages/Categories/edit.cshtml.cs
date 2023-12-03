using forthekittens_razor.Data;
using forthekittens_razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace forthekittens_razor.Pages.Categories
{
    
    public class editModel : PageModel
    {
        private readonly Kittensdbcontext_razor _db;
        public editModel(Kittensdbcontext_razor db)
        {
            _db = db;   
        }
        [BindProperty]
        public Category category { get; set; }
        public void OnGet(int? id)
        {
            if(id!=null&&id!=0)
            {
                category = _db.Categories.Find(id);
            }

        }
        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                return RedirectToPage("/categories/index");
            }
            return Page();
        }
    }
}
