using MarketPlace.Application.Orders.Models;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Orders.Commands;

public record OrderItemCreateCommand : ICommand<OrderItemDto>
{
    public OrderItemDto OrderItemDto { get; set; }
}
