namespace OnlineStoreProject.Tests
{
    public class CartIteratorTests
    {
        [Fact]
        public void GetIterator_EmptyCart_HasNextShouldBeFalse()
        {
            var cart = new Cart();

            var iterator = cart.GetIterator();

            Assert.False(iterator.HasNext(), "Для порожнього кошика HasNext має повертати false.");
        }

        [Fact]
        public void GetIterator_WithItems_ShouldIterateOverAllItems()
        {
            var cart = new Cart();
            cart.AddProduct(new Product { Id = 1, Name = "Мишка", Price = 500 }, 1);
            cart.AddProduct(new Product { Id = 2, Name = "Клавіатура", Price = 1500 }, 1);

            var iterator = cart.GetIterator();
            int count = 0;

            while (iterator.HasNext())
            {
                var item = iterator.Next();
                count++;
            }

            Assert.Equal(2, count); 
        }

        [Fact]
        public void AddProduct_SameProductTwice_ShouldIncreaseQuantityNotCount()
        {
            // Arrange
            var cart = new Cart();
            var product = new Product { Id = 1, Name = "Монітор", Price = 5000 };

            // Act
            cart.AddProduct(product, 1);
            cart.AddProduct(product, 2); 

            var iterator = cart.GetIterator();
            int uniqueItemsCount = 0;
            int totalQuantity = 0;

            while (iterator.HasNext())
            {
                var item = iterator.Next();
                uniqueItemsCount++;
                totalQuantity = item.Quantity;
            }

            Assert.Equal(1, uniqueItemsCount); 
            Assert.Equal(3, totalQuantity);  
        }
    }
}