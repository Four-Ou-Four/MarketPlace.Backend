using MarketPlace.Application.Carts.Models;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Carts.Commands;

public record CartItemCreateCommand : ICommand<CartItemDto>
{
    public CartItemDto CartItemDto { get; set; }
}
