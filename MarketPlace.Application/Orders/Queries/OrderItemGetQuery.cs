using MarketPlace.Application.Orders.Models;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Application.Orders.Queries;

public class OrderItemGetQuery : IQuery<ICollection<OrderItemDto>>
{
    public OrderItemFilter OrderItemFilter { get; set; }
}
