using MarketPlace.Application.Carts.Commands;
using MarketPlace.Application.Carts.Services;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Infrastructure.Carts.CommandHandlers;

public class CartDeleteByIdCommandHandler(
    ICartService cartService)
    : ICommandHandler<CartDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(CartDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await cartService.DeleteByIdAsync(request.CartId, cancellationToken: cancellationToken);

        return result is not null;
    }
}