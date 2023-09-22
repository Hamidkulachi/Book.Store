using Book.Store.Data;
using Book.Store.DataAccess.Repository;
using Book.Store.DataAccess.Repository.IRepository;
using Book.Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Book.Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> products = _unitOfWork.Product.GetAll().ToList();
            return View(products);
        }

        public IActionResult UpSert(int? id)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            if (id==0||id==null)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
                return View(productVM);
            }
            
        }
        [HttpPost]
        public IActionResult UpSert(ProductVM productVM)
        {
            if (productVM.Product.Id==0|| productVM.Product.Id ==null)
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Product.Add(productVM.Product);
                    _unitOfWork.Save();
                    TempData["success"] = "Product created successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(productVM);
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Product.Update(productVM.Product);
                    _unitOfWork.Save();
                    TempData["success"] = "Product is updated successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(productVM);
                }
            }
            
        }
       
       
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Product product = _unitOfWork.Product.Get(u => u.Id == id);
            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product product = _unitOfWork.Product.Get(u => u.Id == id);
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Save();
            TempData["success"] = "Product is deleted successfully";
            return RedirectToAction("Index");
        }
    }
}



