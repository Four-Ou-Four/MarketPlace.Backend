using AutoMapper;
using MarketPlace.Application.Orders.Models;
using MarketPlace.Application.Orders.Queries;
using MarketPlace.Application.Orders.Services;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Infrastructure.Orders.QueryHandlers;

public class OrderItemGetByIdQueryHandler(
    IMapper mapper,
    IOrderItemService orderItemService)
    : IQueryHandler<OrderItemGetByIdQuery, OrderItemDto>
{
    public async Task<OrderItemDto> Handle(OrderItemGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await orderItemService.GetByIdAsync(request.OrderItemId, cancellationToken: cancellationToken);

        return mapper.Map<OrderItemDto>(result);
    }
}
