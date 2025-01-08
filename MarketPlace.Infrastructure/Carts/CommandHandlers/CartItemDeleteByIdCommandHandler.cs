using MarketPlace.Application.Carts.Commands;
using MarketPlace.Application.Carts.Services;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Infrastructure.Carts.CommandHandlers;

public class CartItemDeleteByIdCommandHandler(
    ICartItemService cartItemService)
    : ICommandHandler<CartItemDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(CartItemDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await cartItemService.DeleteByIdAsync(request.CartItemId, cancellationToken: cancellationToken);

        return result is not null;
    }
}