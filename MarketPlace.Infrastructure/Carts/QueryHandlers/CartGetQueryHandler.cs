using AutoMapper;
using MarketPlace.Application.Carts.Models;
using MarketPlace.Application.Carts.Queries;
using MarketPlace.Application.Carts.Services;
using MarketPlace.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Carts.QueryHandlers;

public class CartGetQueryHandler(
    IMapper mapper,
    ICartService cartService)
    : IQueryHandler<CartGetQuery, ICollection<CartDto>>
{
    public async Task<ICollection<CartDto>> Handle(CartGetQuery request, CancellationToken cancellationToken)
    {
        var result = await cartService.Get(
            request.CartFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<CartDto>>(result);
    }
}
