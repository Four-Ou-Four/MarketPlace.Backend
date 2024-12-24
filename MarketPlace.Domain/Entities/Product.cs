using MarketPlace.Domain.Common.Entities;

namespace MarketPlace.Domain.Entities;

public class Product : AuditableEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public float Rating { get; set; }
    public User User { get; set; }
    public Category Category { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }
    public IEnumerable<CartItem> CartItems { get; set; }
    public IEnumerable<Comment> Comments { get; set; }
    public IEnumerable<Rating> Ratings { get; set; }
}
