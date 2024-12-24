using MarketPlace.Domain.Entities;

namespace MarketPlace.Application.Orders.Models;

public class OrderItemDto
{
    public Guid? Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}
