using Book.Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book.Store.Controllers
{
    public class CateogoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            return View();
        }
        public IActionResult Edit(int? id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            return View();
        }
        public IActionResult Delete(int? id)
        {
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            return View();
        }
    }
}
