using ASPproject.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPproject.Infrastructure;
using ASPproject.Models.ViewModels;

namespace ASPproject.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _repository;
        private Cart _cart;

        public CartController(IProductRepository repo, Cart cartService)
        {
            _repository = repo;
            _cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = _cart, ReturnUrl = returnUrl });
        }


        public RedirectToActionResult AddToCart(int productID, string returnUrl)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.ProductID == productID);
            if(product != null)
            {
                _cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productID, string returnUrl)
        {
            Product product = _repository.Products.FirstOrDefault(p => p.ProductID == productID);
            if(product != null)
            {
                _cart.RemoveItem(product);
            
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        //private void SaveCart(Cart cart)
        //{
        //    HttpContext.Session.SetJson("Cart", cart);
        //}
        //private Cart GetCart()
        //{
        //    var cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart() ;
        //    return cart;
        //}
    }
}
