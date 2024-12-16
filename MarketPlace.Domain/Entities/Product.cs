using MarketPlace.Domain.Common.Entities;

namespace MarketPlace.Domain.Entities;

public class Product : AuditableEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public IEnumerable<Category> Categories { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }
}
