using Microsoft.AspNetCore.Mvc;
using ASPproject.Models;
using System.Linq;
using ASPproject.Models.ViewModels;
namespace ASPproject.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;

        public int pageSize = 4;
        public ProductController(IProductRepository repository)
        {
            productRepository = repository;
        }
        public ViewResult List(string category, int productPage = 1) => View(new ProductListViewModel {
            Products = productRepository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * pageSize)
                .Take(pageSize),
            PagingInfo = new PagingInfo {
                CurrentPage = productPage,
                ItemsPerPage = pageSize,
                TotalItems = category == null ? productRepository.Products.Count() :
                productRepository.Products.Where(e=>e.Category == category).Count()
            },
            CurrentCategory = category

        });
    }
}
