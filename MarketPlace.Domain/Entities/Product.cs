using MarketPlace.Domain.Common.Entities;

namespace MarketPlace.Domain.Entities;

public class Product : AuditableEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public User User { get; set; }
    public Category Category { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }
}
