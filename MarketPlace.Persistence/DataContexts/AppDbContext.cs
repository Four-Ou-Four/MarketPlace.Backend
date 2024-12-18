using MarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Persistence.DataContexts;

public class AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    
    //Identity
    public DbSet<User> Users => Set<User>();
    public DbSet<UserSettings> UserSettings => Set<UserSettings>();
    public DbSet<UserInfoVerificationCode> UserInfoVerificationCodes => Set<UserInfoVerificationCode>();
    public DbSet<AccessToken> AccessTokens => Set<AccessToken>();
    
    //Notification
    public DbSet<EmailTemplate> EmailTemplates => Set<EmailTemplate>();
    public DbSet<EmailHistory> EmailHistories => Set<EmailHistory>();
    
    //Cart entities
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();

    //Product entities
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();

    //Order entities
    public DbSet<OrderItem> Orders => Set<OrderItem>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
}
