using MarketPlace.Domain.Common.Entities;

namespace MarketPlace.Domain.Entities;

public class Rating : AuditableEntity
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Stars { get; set; }
    public User User { get; set; }
    public Product Product { get; set; }
}
