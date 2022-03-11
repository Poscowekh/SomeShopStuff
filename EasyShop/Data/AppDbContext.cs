using EasyShop.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.Data;

public class AppDbContext : DbContext
{
    public AppDbContext() { }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { set; get; }
    public DbSet<Cart> Carts { set; get; }
    public DbSet<Order> Orders { set; get; }
    
    public DbSet<Manufacturer> Manufacturers { set; get; }
    public DbSet<Product> Products { set; get; }
    public DbSet<ProductScore> ProductScores { set; get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<ProductScore>()
            .HasKey(ps => new { ps.UserId, ps.ProductId } );

        modelBuilder
            .Entity<Order>()
            .HasOne(o => o.User)
            .WithOne()
            .HasForeignKey<Order>(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}