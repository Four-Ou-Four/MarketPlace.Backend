using AutoMapper;
using MarketPlace.Application.Carts.Models;
using MarketPlace.Application.Carts.Queries;
using MarketPlace.Application.Carts.Services;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Infrastructure.Carts.QueryHandlers;

public class CartItemGetByIdQueryHandler(
    IMapper mapper,
    ICartItemService cartItemService)
    : IQueryHandler<CartItemGetByIdQuery, CartItemDto>
{
    public async Task<CartItemDto> Handle(CartItemGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await cartItemService.GetByIdAsync(request.CartItemId, cancellationToken: cancellationToken);

        return mapper.Map<CartItemDto>(result);
    }
}
