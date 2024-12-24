using MarketPlace.Application.Orders.Models;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Application.Orders.Queries;

public class OrderItemGetByIdQuery : IQuery<OrderItemDto?>
{
    public Guid OrderItemId { get; set; }
}
