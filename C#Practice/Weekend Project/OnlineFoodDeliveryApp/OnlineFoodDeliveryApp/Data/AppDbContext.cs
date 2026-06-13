using Microsoft.EntityFrameworkCore;
using OnlineFoodOrder.API.Models;

namespace OnlineFoodOrder.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Tables
    public DbSet<Category> Categories { get; set; }
    public DbSet<FoodItem> FoodItems { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<Category>()
            .HasMany(c => c.FoodItems)
            .WithOne(f => f.Category)
            .HasForeignKey(f => f.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

      
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

       
        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

       
        modelBuilder.Entity<FoodItem>()
            .HasMany(f => f.OrderDetails)
            .WithOne(od => od.FoodItem)
            .HasForeignKey(od => od.FoodId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Category>()
            .Property(c => c.CategoryName)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<FoodItem>()
            .Property(f => f.FoodName)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Customer>()
            .Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Order>()
            .Property(o => o.Status)
            .HasMaxLength(30)
            .IsRequired();
    }
}