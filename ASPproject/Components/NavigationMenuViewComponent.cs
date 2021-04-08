using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ASPproject.Models;

namespace ASPproject.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository _repository;
        public NavigationMenuViewComponent(IProductRepository repo)
        {
            _repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            // should use viewmodel class to pass category to the view
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_repository.Products
                .Select(x=>x.Category)
                .Distinct()
                .OrderBy(x=>x));
        }
    }
}
