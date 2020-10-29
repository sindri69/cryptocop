using Microsoft.EntityFrameworkCore;
using Cryptocop.Software.API.Models.Entities;


namespace Cryptocop.Software.API.Repositories.Contexts
{
  public class CryptocopDbContext : DbContext
  {
    public CryptocopDbContext(DbContextOptions<CryptocopDbContext> options) : base(options) {}
  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Message>()
        .HasOne(modelBuilder => modelBuilder.userFrom)
        .WithMany(uint => uint.MessagesSent);

      modelBuilder.Entity<Message>()
      .hasOne(modelBuilder-> m.UserTo)
      .WithMany(uint => uint.MessagesRecieved);
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