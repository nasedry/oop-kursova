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
        public void Test2_WithItems_ShouldIterateOverAllItems()
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
        public void Test3_AddSameProductTwice_ShouldSumQuantity()
        {
            var cart = new Cart();
            var product = new Product { Id = 10, Name = "Item", Price = 50 };
            
            cart.AddProduct(product, 2);
            cart.AddProduct(product, 3);

            var item = cart.GetIterator().Next();
            Assert.Equal(5, item.Quantity);
        }

        [Fact]
        public void Test4_GetTotal_ShouldReturnCorrectSum()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Name = "A", Price = 100 }, 2); 
            cart.AddProduct(new Product { Name = "B", Price = 50 }, 3);  

            Assert.Equal(350, cart.GetTotal());
        }

        [Fact]
        public void Test5_Clear_ShouldResetCart()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Name = "T", Price = 10 }, 1);
            
            cart.Clear();

            Assert.Equal(0, cart.GetTotal());
            Assert.False(cart.GetIterator().HasNext());
        }

        [Fact]
        public void Test6_ApplyDiscount_CheckCalculation()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Price = 1000 }, 1);
            
            decimal totalWithDiscount = cart.GetTotal() * 0.9m;

            Assert.Equal(900, totalWithDiscount);
        }

        [Fact]
        public void Test7_IteratorNext_ShouldReturnCorrectProduct()
        {
            var cart = new Cart();
            var product = new Product { Name = "Unique", Price = 777 };
            cart.AddProduct(product, 1);

            var item = cart.GetIterator().Next();

            Assert.Equal("Unique", item.Product.Name);
            Assert.Equal(777, item.Product.Price);
        }

        [Fact]
        public void Test8_AddZeroQuantity_ShouldNotAddItem()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Name = "None", Price = 100 }, 0);

            Assert.False(cart.GetIterator().HasNext());
        }

        [Fact]
        public void Test9_LargeQuantity_ShouldCalculateCorrectly()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Price = 10 }, 1000); 

            Assert.Equal(10000, cart.GetTotal());
        }

        [Fact]
        public void Test10_IteratorOrder_ShouldBeConsistent()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Name = "First" }, 1);
            cart.AddProduct(new Product { Name = "Second" }, 1);

            var iterator = cart.GetIterator();
            
            Assert.Equal("First", iterator.Next().Product.Name);
            Assert.Equal("Second", iterator.Next().Product.Name);
        }

        [Fact]
        public void Test11_NextOnEmptyIterator_ShouldThrowException()
        {
            var cart = new Cart();
            var iterator = cart.GetIterator();

            Assert.Throws<IndexOutOfRangeException>(() => iterator.Next());
        }
    }
}