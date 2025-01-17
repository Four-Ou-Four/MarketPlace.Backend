using AutoMapper;
using MarketPlace.Application.Orders.Models;
using MarketPlace.Application.Orders.Queries;
using MarketPlace.Application.Orders.Services;
using MarketPlace.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore; 

namespace MarketPlace.Infrastructure.Orders.QueryHandlers;

public class OrderItemGetQueryHandler(
    IMapper mapper,
    IOrderItemService orderItemService)
    : IQueryHandler<OrderItemGetQuery, ICollection<OrderItemDto>>
{
    public async Task<ICollection<OrderItemDto>> Handle(OrderItemGetQuery request, CancellationToken cancellationToken)
    {
        var result = await orderItemService.Get(
            request.OrderItemFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<OrderItemDto>>(result);
    }
}
