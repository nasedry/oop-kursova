using System.Collections.Generic;
using OnlineStoreProject.Patterns;

namespace OnlineStoreProject.Core
{
    public class Cart
    {
        private readonly List<CartItem> _items = new();

        public void AddProduct(Product product, int quantity)
        {
            if (quantity <= 0)
                return;

            var existingItem = _items.Find(i =>
                i.Product.Id != 0 &&
                i.Product.Id == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _items.Add(new CartItem
                {
                    Product = product,
                    ProductId = product.Id,
                    Quantity = quantity
                });
            }
        }
        public void Clear()
        {
            _items.Clear();
        }

        public decimal GetTotal()
        {
            decimal total = 0;

            foreach (var item in _items)
            {
                total += item.Product.Price * item.Quantity;
            }

            return total;
        }

        public IIterator<CartItem> GetIterator()
        {
            return new CartIterator(_items);
        }
    }
}