using Microsoft.EntityFrameworkCore;
using Cryptocop.Software.API.Models.Entities;


namespace Cryptocop.Software.API.Repositories.Contexts
{
  public class CryptocopDbContext : DbContext
  {
    public CryptocopDbContext(DbContextOptions<CryptocopDbContext> options) : base(options) {}
  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ShoppingCartItem>()
        .HasOne(m => m.ShoppingCart)
        .WithMany(u => u.ShoppingCartItems);

      modelBuilder.Entity<ShoppingCart>()
        .HasOne(m => m.User)
        .WithOne(u => u.ShoppingCart);
      
      modelBuilder.Entity<Address>()
        .HasOne(m => m.User)
        .WithMany(u => u.Addresses);
      
      modelBuilder.Entity<PaymentCard>()
        .HasOne(m => m.User)
        .WithMany(u => u.PaymentCards);
      
      modelBuilder.Entity<Order>()
        .HasOne(m => m.User)
        .WithMany(u => u.Orders);

      modelBuilder.Entity<OrderItem>()
        .HasOne(m => m.Order)
        .WithMany(u => u.OrderItems);
    }

    //setup dbsets which function as our tables
    public DbSet<User> Users {get; set;}
    public DbSet<JwtToken> JwtTokens {get; set;}
    public DbSet<Address> Addresses {get; set;}
    public DbSet<Order> Orders {get; set;}
    public DbSet<OrderItem> OrderItems {get; set;}
    public DbSet<PaymentCard> PaymentCards {get; set;}
    public DbSet<ShoppingCartItem> ShoppingCartItems {get; set;}
    
  }

}