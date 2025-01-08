using AutoMapper;
using MarketPlace.Application.Carts.Commands;
using MarketPlace.Application.Carts.Models;
using MarketPlace.Application.Carts.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Infrastructure.Carts.CommandHandlers;

public class CartUpdateCommandHandler(
    IMapper mapper,
    ICartService cartService) : ICommandHandler<CartUpdateCommand, CartDto>
{
    public async Task<CartDto> Handle(CartUpdateCommand request, CancellationToken cancellationToken)
    {
        var cart = mapper.Map<Cart>(request.CartDto);

        var createdCart = await cartService.UpdateAsync(cart, cancellationToken: cancellationToken);

        return mapper.Map<CartDto>(createdCart);
    }
}
