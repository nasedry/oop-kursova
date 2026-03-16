namespace OnlineStoreProject.Core
{
    public class CartItem
    {
        public int Id { get; set; }   // Primary Key

        public int ProductId { get; set; }   // Foreign Key

        public Product Product { get; set; } = null!;  // Navigation property

        public int Quantity { get; set; }
    }
}