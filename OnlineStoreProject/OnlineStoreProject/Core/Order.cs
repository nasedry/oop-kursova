using System;
using System.Collections.Generic;

namespace OnlineStoreProject.Core
{
    public class Order
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public List<CartItem> Items { get; set; } = new();
    }
}