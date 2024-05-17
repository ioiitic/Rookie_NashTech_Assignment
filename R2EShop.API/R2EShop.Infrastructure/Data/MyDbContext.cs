using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using R2EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Infrastructure.Data
{
    public class MyDbContext : DbContext
    {
        private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../R2EShop.API/"))
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseLoggerFactory(_loggerFactory)
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Address);
        }
    }
}
