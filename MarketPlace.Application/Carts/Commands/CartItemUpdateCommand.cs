using MarketPlace.Application.Carts.Models;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Carts.Commands;

public record CartItemUpdateCommand : ICommand<CartItemDto>
{
    public CartItemDto CartItemDto { get; set; }
}
