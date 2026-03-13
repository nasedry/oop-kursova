using System;
using OnlineStoreProject.Core;

namespace OnlineStoreProject.Patterns
{
    public class OrderBuilder : IOrderBuilder
    {
        private Order _order = new Order();

        private PricingStrategy _pricingStrategy = new NoDiscountStrategy();

        public IOrderBuilder SetCustomer(string name)
        {
            _order.CustomerName = name;
            return this;
        }

        public IOrderBuilder SetAddress(string address)
        {
            _order.Address = address;
            return this;
        }

        public IOrderBuilder SetPricingStrategy(PricingStrategy strategy)
        {
            _pricingStrategy = strategy;
            return this;
        }

        public IOrderBuilder AddItemsFromCart(IIterator<CartItem> cartIterator)
        {
            decimal rawTotal = 0;

            while (cartIterator.HasNext())
            {
                var item = cartIterator.Next();
                var orderItem = new CartItem { ProductId = item.ProductId, Quantity = item.Quantity };
                _order.Items.Add(orderItem);

                rawTotal += item.Product.Price * item.Quantity;
            }

            _order.TotalPrice = rawTotal;
            return this;
        }

        public Order Build()
        {
            if (string.IsNullOrWhiteSpace(_order.CustomerName))
                throw new InvalidOperationException("Ім'я клієнта не може бути порожнім.");
            if (string.IsNullOrWhiteSpace(_order.Address))
                throw new InvalidOperationException("Адреса доставки не може бути порожньою.");
            if (_order.Items.Count == 0)
                throw new InvalidOperationException("Кошик порожній. Додайте товари для замовлення.");

            _order.TotalPrice = _pricingStrategy.CalculateTotal(_order.TotalPrice);

            var finishedOrder = _order;
            _order = new Order();
            return finishedOrder;
        }
    }
}