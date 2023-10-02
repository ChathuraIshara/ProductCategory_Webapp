using BulkywebRazor_Temp.Data;
using BulkywebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkywebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;


        public Category? category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public void OnGet(int? id)
        {
            if(id != null && id != 0)
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
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
