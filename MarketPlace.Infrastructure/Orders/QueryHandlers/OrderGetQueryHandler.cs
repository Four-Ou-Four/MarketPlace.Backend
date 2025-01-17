using AutoMapper;
using MarketPlace.Application.Orders.Models;
using MarketPlace.Application.Orders.Queries;
using MarketPlace.Application.Orders.Services;
using MarketPlace.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Orders.QueryHandlers;

public class OrderGetQueryHandler(
    IMapper mapper,
    IOrderService orderService)
    : IQueryHandler<OrderGetQuery, ICollection<OrderDto>>
{
    public async Task<ICollection<OrderDto>> Handle(OrderGetQuery request, CancellationToken cancellationToken)
    {
        var result = await orderService.Get(
            request.OrderFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<OrderDto>>(result);
    }
}
