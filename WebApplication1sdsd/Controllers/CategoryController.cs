using Microsoft.AspNetCore.Mvc;
using WebApplication1sdsd.Data;
using WebApplication1sdsd.Models;

namespace WebApplication1sdsd.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();
            return View(categories);
        }
        public IActionResult ListDetails()
        {
            return View();

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Category Name and Display order should not be equal!");
            }
            if(obj.Name=="test")
            {
                ModelState.AddModelError("","test is not valid!");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category created succesfully";
                return RedirectToAction("Index", "Category");

            }
            return View();
           

        }
        public IActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            Category? category = _db.Categories.Find(id);
            if (category==null)
            {
                return NotFound();
                
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Category Name and Display order should not be equal!");
            }
            if (obj.Name == "test")
            {
                ModelState.AddModelError("", "test is not valid!");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Edited Succesfully!";
                return RedirectToAction("Index", "Category");

            }
            return View();


        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category? category = _db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();

            }
            return View(category);
        }
        [HttpPost,ActionName("delete")]
        public IActionResult DeletePost(int? id )
        {
            Category? category = _db.Categories.Find(id);
            if (category==null)
            {
                return NotFound();
                
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["Success"] = "Category Deleted succesfully!";
            return RedirectToAction("Index","Category");


        }

    }
}
