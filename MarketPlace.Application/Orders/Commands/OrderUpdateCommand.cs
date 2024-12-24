using MarketPlace.Domain.Common.Commands;
using MarketPlace.Application.Orders.Models;

namespace MarketPlace.Application.Orders.Commands;

public class OrderUpdateCommand : ICommand<OrderDto>
{
    public OrderDto OrderDto { get; set; }
}
