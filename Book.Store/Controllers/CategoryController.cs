using Book.Store.Data;
using Book.Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book.Store.Controllers
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
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id==0||id==null)
            {
                return NotFound();
            }
            Category category = _db.Categories.FirstOrDefault(u => u.Id == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == 0||id==null)
            {
                return NotFound();
            }
            Category category = _db.Categories.FirstOrDefault(u => u.Id == id);
            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id==null||id==0)
            {
                return NotFound();
            }
            Category category = _db.Categories.FirstOrDefault(u => u.Id == id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
