using AutoMapper;
using MarketPlace.Application.Carts.Commands;
using MarketPlace.Application.Carts.Models;
using MarketPlace.Application.Carts.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Infrastructure.Carts.CommandHandlers;

public class CartItemCreateCommandHandler(
    IMapper mapper,
    ICartItemService cartItemService) : ICommandHandler<CartItemCreateCommand, CartItemDto>
{
    public async Task<CartItemDto> Handle(CartItemCreateCommand request, CancellationToken cancellationToken)
    {
        var cartItem = mapper.Map<CartItem>(request.CartItemDto);

        var createdCartItem = await cartItemService.CreateAsync(cartItem, cancellationToken: cancellationToken);

        return mapper.Map<CartItemDto>(createdCartItem);
    }
}
