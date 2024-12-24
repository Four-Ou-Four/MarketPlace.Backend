using MarketPlace.Domain.Common.Entities;

namespace MarketPlace.Domain.Entities;

public class OrderItem : AuditableEntity
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
}
