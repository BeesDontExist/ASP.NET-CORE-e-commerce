using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPproject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Product myProduct = new Product
            {
                ProductID = 1,
                Name = "Kajak",
                Description = "Jednoosobowa Łódka",
                Category = "sporty wodne",
                Price = 275M
            };
            return View(myProduct);
        }
    }
}
