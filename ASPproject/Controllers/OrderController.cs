using ASPproject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ASPproject.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _repository;
        private Cart _cart;

        public OrderController(IOrderRepository repoService, Cart cartSrvice)
        {
            _repository = repoService;
            _cart = cartSrvice;
        }
        public ViewResult Checkout()
        {
            return View(new Order());   
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (_cart.Items.Count() == 0)
                ModelState.AddModelError("", "Cart is empty");

            if(ModelState.IsValid)
            {
                order.Items = _cart.Items.ToArray();
                _repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {
            _cart.Clear();
            return View();
        }

    }
}
