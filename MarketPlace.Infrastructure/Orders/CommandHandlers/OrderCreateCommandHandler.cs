using AutoMapper;
using MarketPlace.Application.Orders.Commands;
using MarketPlace.Application.Orders.Models;
using MarketPlace.Application.Orders.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Infrastructure.Orders.CommandHandlers;

public class OrderCreateCommandHandler(
    IMapper mapper,
    IOrderService orderService) : ICommandHandler<OrderCreateCommand, OrderDto>
{
    public async Task<OrderDto> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
    {
        var order = mapper.Map<Order>(request.OrderDto);

        var createdOrder = await orderService.CreateAsync(order, cancellationToken: cancellationToken);

        return mapper.Map<OrderDto>(createdOrder);
    }
}
