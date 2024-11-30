using _22._10.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace _22._10.Context
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                        .HasOne(o => o.Customer)
                        .WithMany(c => c.Orders)
                        .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Order>()
                        .HasMany(o => o.Products)
                        .WithMany(p => p.Orders)
                        .UsingEntity(e => e.ToTable("OrderProducts"));

            modelBuilder.Entity<Product>()
                        .Property(p => p.RowVersion)
                        .IsRowVersion();
        }
    }
}
