using System;

namespace OnlineStoreProject.Tests
{
    public class OrderBuilderTests
    {
        [Fact]
        public void Build_WithValidData_ShouldCreateOrderAndCalculateTotalPrice()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Id = 1, Name = "Ноутбук", Price = 30000 }, 1); 
            cart.AddProduct(new Product { Id = 2, Name = "Мишка", Price = 1000 }, 2); 

            var builder = new OrderBuilder();

            var order = builder
                .SetCustomer("Іван Франко")
                .SetAddress("м. Львів, вул. Університетська, 1")
                .AddItemsFromCart(cart.GetIterator()) 
                .Build();

            Assert.NotNull(order);
            Assert.Equal("Іван Франко", order.CustomerName);
            Assert.Equal("м. Львів, вул. Університетська, 1", order.Address);
            Assert.Equal(32000, order.TotalPrice);
            Assert.Equal(2, order.Items.Count);   
        }

        [Fact]
        public void Build_EmptyCustomerName_ShouldThrowInvalidOperationException()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Id = 1, Name = "Тест", Price = 100 }, 1);

            var builder = new OrderBuilder();

            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                builder
                    .SetAddress("Київ")
                    .AddItemsFromCart(cart.GetIterator())
                    .Build();
            });

            Assert.Equal("Ім'я клієнта не може бути порожнім.", exception.Message);
        }

        [Fact]
        public void Build_EmptyAddress_ShouldThrowInvalidOperationException()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Id = 1, Name = "Тест", Price = 100 }, 1);

            var builder = new OrderBuilder();

            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                builder
                    .SetCustomer("Тарас Шевченко")
                    .AddItemsFromCart(cart.GetIterator())
                    .Build();
            });

            Assert.Equal("Адреса доставки не може бути порожньою.", exception.Message);
        }

        [Fact]
        public void Build_EmptyCart_ShouldThrowInvalidOperationException()
        {
            var emptyCart = new Cart(); 
            var builder = new OrderBuilder();

            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                builder
                    .SetCustomer("Леся Українка")
                    .SetAddress("м. Луцьк")
                    .AddItemsFromCart(emptyCart.GetIterator()) 
                    .Build();
            });

            Assert.Equal("Кошик порожній. Додайте товари для замовлення.", exception.Message);
        }

        [Fact]
        public void Build_WithPercentageStrategy_ShouldCalculateDiscountCorrectly()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Id = 1, Name = "Телевізор", Price = 10000 }, 1);

            var builder = new OrderBuilder();
            var discountStrategy = new PercentageDiscountStrategy(10); 

            var order = builder
                .SetCustomer("Іван")
                .SetAddress("Київ")
                .AddItemsFromCart(cart.GetIterator())
                .SetPricingStrategy(discountStrategy) 
                .Build();

            Assert.Equal(9000, order.TotalPrice);
        }
    }
}