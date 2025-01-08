using AutoMapper;
using MarketPlace.Application.Carts.Models;
using MarketPlace.Application.Carts.Queries;
using MarketPlace.Application.Carts.Services;
using MarketPlace.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Carts.QueryHandlers;

public class CartItemGetQueryHandler(
    IMapper mapper,
    ICartItemService cartItemService)
    : IQueryHandler<CartItemGetQuery, ICollection<CartItemDto>>
{
    public async Task<ICollection<CartItemDto>> Handle(CartItemGetQuery request, CancellationToken cancellationToken)
    {
        var result = await cartItemService.Get(
            request.CartItemFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<CartItemDto>>(result);
    }
}
