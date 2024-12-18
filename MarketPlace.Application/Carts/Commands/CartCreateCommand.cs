using MarketPlace.Application.Carts.Models;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Carts.Commands;

public record CartCreateCommand : ICommand<CartDto>
{
    public CartDto CartDto { get; set; }
}
