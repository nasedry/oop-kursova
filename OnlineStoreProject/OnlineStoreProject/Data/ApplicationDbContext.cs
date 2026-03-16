using Microsoft.EntityFrameworkCore;
using OnlineStoreProject.Core;
using System;
using System.IO;

namespace OnlineStoreProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public ApplicationDbContext()
        {
            // Цей метод перевіряє, чи є база, і створює її разом з таблицями
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Вказуємо точний шлях: папка програми + ім'я файлу store.db
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "store.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Початкові дані (Seed Data)
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Ноутбук ASUS ROG", Price = 45000m },
                new Product { Id = 2, Name = "Мишка Logitech G Pro", Price = 3500m },
                new Product { Id = 3, Name = "Клавіатура Keychron K2", Price = 4000m }
            );
        }
    }
}