using MarketPlace.Domain.Common.Entities;

namespace MarketPlace.Domain.Entities;

public class CartItem : AuditableEntity
{
    public Guid CartId { get; set; }
    public Cart Cart { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}
