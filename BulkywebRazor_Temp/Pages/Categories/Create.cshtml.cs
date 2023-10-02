using BulkywebRazor_Temp.Data;
using BulkywebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.ExceptionServices;

namespace BulkywebRazor_Temp.Pages.Categories

{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        
        public Category category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public void OnGet()
        {


            

        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToPage("Index");

            }
            return Page();
            

        }
    }
}
