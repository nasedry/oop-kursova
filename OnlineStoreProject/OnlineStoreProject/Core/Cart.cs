using System.Collections.Generic;
using OnlineStoreProject.Patterns; 

namespace OnlineStoreProject.Core
{
    public class Cart
    {
        private readonly List<CartItem> _items = new();

        public void AddProduct(Product product, int quantity)
        {
            var existingItem = _items.Find(i => i.Product.Id == product.Id);

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

        public IIterator<CartItem> GetIterator()
        {
            return new CartIterator(_items);
        }
    }
}