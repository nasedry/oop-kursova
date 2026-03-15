using System.Collections.Generic;
using OnlineStoreProject.Core;

namespace OnlineStoreProject.Patterns
{
    public class CartIterator : IIterator<CartItem>
    {
        private readonly List<CartItem> _items;
        private int _position = 0;

        public CartIterator(List<CartItem> items)
        {
            _items = items;
        }

        public bool HasNext()
        {
            return _position < _items.Count;
        }

        public CartItem Next()
        {
            var item = _items[_position];
            _position++;
            return item;
        }
    }
}