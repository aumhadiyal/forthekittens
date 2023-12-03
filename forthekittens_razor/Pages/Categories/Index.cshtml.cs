using forthekittens_razor.Data;
using forthekittens_razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace forthekittens_razor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Kittensdbcontext_razor _db;
        public IndexModel(Kittensdbcontext_razor db)
        {
            _db = db;
        }
        public List<Category> CategoriesList { get; set; }
        

        public void OnGet() 
        {
            CategoriesList = _db.Categories.ToList();
        }
    }
}
