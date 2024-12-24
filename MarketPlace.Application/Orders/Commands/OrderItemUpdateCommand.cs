using MarketPlace.Application.Orders.Models;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Orders.Commands;

public class OrderItemUpdateCommand : ICommand<OrderItemDto>
{
    public OrderItemDto OrderItemDto { get; set; }
}
