using Xunit;
using OnlineStoreProject.Core;
using OnlineStoreProject.Patterns;
using System;

namespace OnlineStoreProject.Tests
{
    public class CartIteratorTests
    {
        [Fact]
        public void Test1_EmptyCart_HasNextShouldBeFalse()
        {
            var cart = new Cart();
            var iterator = cart.GetIterator();
            Assert.False(iterator.HasNext());
        }

        [Fact]
        public void Test2_WithItems_ShouldIterateCorrectly()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Id = 1, Name = "P1", Price = 100 }, 1);
            cart.AddProduct(new Product { Id = 2, Name = "P2", Price = 200 }, 1);

            var iterator = cart.GetIterator();
            int count = 0;
            while (iterator.HasNext()) { iterator.Next(); count++; }

            Assert.Equal(2, count);
        }

        [Fact]
        public void Test3_SameProduct_ShouldSumQuantity()
        {
            var cart = new Cart();
            var product = new Product { Id = 1, Name = "Item", Price = 50 };
            
            cart.AddProduct(product, 2);
            cart.AddProduct(product, 3);

            var item = cart.GetIterator().Next();
            Assert.Equal(5, item.Quantity);
        }

        [Fact]
        public void Test4_Total_ShouldBeCorrect()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Name = "A", Price = 100 }, 2); 
            cart.AddProduct(new Product { Name = "B", Price = 50 }, 3);  

            Assert.Equal(350, cart.GetTotal());
        }

        [Fact]
        public void Test5_Clear_ShouldEmptyCart()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Name = "T", Price = 10 }, 1);
            cart.Clear();

            Assert.Equal(0, cart.GetTotal());
            Assert.False(cart.GetIterator().HasNext());
        }

        [Fact]
        public void Test6_Discount_CheckCalculation()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Price = 1000 }, 1);
            decimal totalWithDiscount = cart.GetTotal() * 0.9m;

            Assert.Equal(900, totalWithDiscount);
        }

        [Fact]
        public void Test7_Next_ShouldReturnValidProduct()
        {
            var cart = new Cart();
            var product = new Product { Name = "Data", Price = 500 };
            cart.AddProduct(product, 1);

            var item = cart.GetIterator().Next();

            Assert.Equal("Data", item.Product.Name);
            Assert.Equal(500, item.Product.Price);
        }

        [Fact]
        public void Test8_ZeroQuantity_ShouldNotAdd()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Name = "Zero", Price = 100 }, 0);

            Assert.False(cart.GetIterator().HasNext());
        }

        [Fact]
        public void Test9_LargeSum_ShouldCalculate()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Price = 100 }, 100); 

            Assert.Equal(10000, cart.GetTotal());
        }

        [Fact]
        public void Test10_Order_ShouldBeMaintained()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Name = "First" }, 1);
            cart.AddProduct(new Product { Name = "Second" }, 1);

            var iterator = cart.GetIterator();
            
            Assert.Equal("First", iterator.Next().Product.Name);
            Assert.Equal("Second", iterator.Next().Product.Name);
        }
    }
}