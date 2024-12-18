using MarketPlace.Application.Carts.Models;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Carts.Commands;

public record CartUpdateCommand : ICommand<CartDto>
{
    public CartDto CartDto { get; set; }
}
