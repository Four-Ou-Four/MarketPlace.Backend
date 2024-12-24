using MarketPlace.Application.Orders.Models;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Orders.Commands;

public record OrderCreateCommand : ICommand<OrderDto>
{
    public OrderDto OrderDto { get; set; }
}
