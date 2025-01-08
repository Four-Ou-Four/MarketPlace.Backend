using AutoMapper;
using MarketPlace.Application.Carts.Commands;
using MarketPlace.Application.Carts.Models;
using MarketPlace.Application.Carts.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Infrastructure.Carts.CommandHandlers;

public class CartCreateCommandHandler(
    IMapper mapper,
    ICartService cartService) : ICommandHandler<CartCreateCommand, CartDto>
{
    public async Task<CartDto> Handle(CartCreateCommand request, CancellationToken cancellationToken)
    {
        var cart = mapper.Map<Cart>(request.CartDto);

        var createdCart = await cartService.CreateAsync(cart, cancellationToken: cancellationToken);

        return mapper.Map<CartDto>(createdCart);
    }
}
