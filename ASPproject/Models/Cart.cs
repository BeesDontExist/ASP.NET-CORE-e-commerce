using System.Collections.Generic;
using System.Linq;

namespace ASPproject.Models
{
    public class Cart
    {
        private List<CartItem> _itemCollection = new List<CartItem>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartItem item = _itemCollection.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            if (item == null)
                _itemCollection.Add(new CartItem { Product = product, Quantity = quantity });
            else
                item.Quantity += quantity;
        }

        public virtual void RemoveItem(Product product)
        {
            _itemCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        public virtual decimal ComputeTotalValue()
        {
            return _itemCollection.Sum(p => p.Quantity * p.Product.Price);
        }

        public virtual void Clear() => _itemCollection.Clear();

        public virtual IEnumerable<CartItem> Items => _itemCollection;
    }

    public class CartItem
    {
        public int CartItemID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
