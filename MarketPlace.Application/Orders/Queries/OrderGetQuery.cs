using MarketPlace.Domain.Common.Queries;
using MarketPlace.Application.Orders.Models;

namespace MarketPlace.Application.Orders.Queries;

public class OrderGetQuery : IQuery<ICollection<OrderDto>>
{
    public OrderFilter OrderFilter { get; set; }
}
