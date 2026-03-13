using Microsoft.EntityFrameworkCore;
using OnlineStoreProject.Core;

namespace OnlineStoreProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=store.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Ноутбук ASUS ROG", Price = 45000m },
                new Product { Id = 2, Name = "Мишка Logitech G Pro", Price = 3500m },
                new Product { Id = 3, Name = "Клавіатура Keychron K2", Price = 4000m }
            );
        }
    }
}