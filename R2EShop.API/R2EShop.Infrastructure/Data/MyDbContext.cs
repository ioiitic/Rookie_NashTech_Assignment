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
        public DbSet<Artwork> Artwork { get; set; }
        public DbSet<CaseColor> CaseColor { get; set; }
        public DbSet<CaseType> CaseType { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<PhoneCase> PhoneCase { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseLoggerFactory(_loggerFactory)
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.OwnsOne(u => u.Address, address =>
                {
                    address.Property(a => a.Street)
                        .HasColumnName("AddressStreet");
                    address.Property(a => a.City)
                        .HasColumnName("AddressCity");
                    address.Property(a => a.State)
                        .HasColumnName("AddressState");
                });
            });

            modelBuilder.Entity<Device>()
                .HasMany(d => d.Devices)
                .WithOne()
                .HasForeignKey(d => d.ParentDeviceId);

            modelBuilder.Entity<Category>()
                .HasMany(d => d.Categories)
                .WithOne()
                .HasForeignKey(d => d.ParentCategoryId);
        }
    }
}
