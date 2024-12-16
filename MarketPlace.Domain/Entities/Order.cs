using MarketPlace.Domain.Common.Entities;

namespace MarketPlace.Domain.Entities;

public class Order : AuditableEntity
{
    public DateTime OrderDate { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public IEnumerable<OrderItem> OrderItems { get; set; }
}
