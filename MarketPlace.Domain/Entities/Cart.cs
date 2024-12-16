using MarketPlace.Domain.Common.Entities;

namespace MarketPlace.Domain.Entities;

public class Cart : AuditableEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public IEnumerable<CartItem> CartItems { get; set; }
}
