using Microsoft.AspNetCore.Mvc;
using MVC_Core_CRUD_OnProductTask1.Repository;
using MVC_Core_CRUD_OnProductTask1.Models;

namespace MVC_Core_CRUD_OnProductTask1.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            List<Product> products = _repo.GetAllProducts();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            Product product = _repo.GetById(id);
            return View(product);
        }

        public IActionResult Create()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _repo.InsertProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Product product = _repo.GetById(id);
            return View(product);
        }

        [HttpPost, ActionName("delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            bool deleted = _repo.DeleteById(id);

            if (deleted)
            {
                TempData["SuccessMessage"] = "Employee deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete employee.";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Product product = _repo.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _repo.UpdateProduct(product.Id, product.Price);
            return RedirectToAction("Index");
        }


    }
}
