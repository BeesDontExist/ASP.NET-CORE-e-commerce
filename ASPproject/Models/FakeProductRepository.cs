using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPproject.Models
{
    public class FakeProductRepository  /*: IProductRepository*/
    {
        public IQueryable<Product> Products => new List<Product> {
            new Product {Name = "Kajak", Price = 25 },
            new Product {Name = "Kapok", Price = 10}
        }.AsQueryable<Product>();
    }
}
