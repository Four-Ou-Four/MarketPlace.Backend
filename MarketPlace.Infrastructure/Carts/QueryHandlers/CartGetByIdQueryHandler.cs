using AutoMapper;
using MarketPlace.Application.Carts.Models;
using MarketPlace.Application.Carts.Queries;
using MarketPlace.Application.Carts.Services;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Infrastructure.Carts.QueryHandlers;

public class CartGetByIdQueryHandler(
    IMapper mapper,
    ICartService cartService)
    : IQueryHandler<CartGetByIdQuery, CartDto>
{
    public async Task<CartDto> Handle(CartGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await cartService.GetByIdAsync(request.CartId, cancellationToken: cancellationToken);

        return mapper.Map<CartDto>(result);
    }
}
