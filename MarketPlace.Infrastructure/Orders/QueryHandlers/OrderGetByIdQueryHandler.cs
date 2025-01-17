using AutoMapper;
using MarketPlace.Application.Orders.Models;
using MarketPlace.Application.Orders.Queries;
using MarketPlace.Application.Orders.Services;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Infrastructure.Orders.QueryHandlers;

public class OrderGetByIdQueryHandler(
    IMapper mapper,
    IOrderService orderService)
    : IQueryHandler<OrderGetByIdQuery, OrderDto>
{
    public async Task<OrderDto> Handle(OrderGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await orderService.GetByIdAsync(request.OrderId, cancellationToken: cancellationToken);

        return mapper.Map<OrderDto>(result);
    }
}
