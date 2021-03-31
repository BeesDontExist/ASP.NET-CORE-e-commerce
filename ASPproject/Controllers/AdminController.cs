using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPproject.Models;


namespace ASPproject.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository _repository;
        public AdminController(IProductRepository repo)
        {
            _repository = repo;
        }

        public IActionResult Index()
        {
            return View(_repository.Products);
        }

        public IActionResult Edit(int productId)
        {
            return View(_repository.Products.FirstOrDefault(p => p.ProductID == productId));
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveProduct(product);
                TempData["message"] = $"Saved: {product.Name}.";
                return RedirectToAction("Index");
            }else
            {
                //Failed validation
                return View(product);
            }
        }
    }
}
