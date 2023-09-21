using Microsoft.AspNetCore.Mvc;

namespace Book.Store.Controllers
{
    public class CateogoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
