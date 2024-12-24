using MarketPlace.Domain.Common.Queries;
using MarketPlace.Application.Orders.Models;

namespace MarketPlace.Application.Orders.Queries;

public class OrderGetByIdQuery : IQuery<OrderDto?>
{
    public Guid OrderId { get; set; }
}
