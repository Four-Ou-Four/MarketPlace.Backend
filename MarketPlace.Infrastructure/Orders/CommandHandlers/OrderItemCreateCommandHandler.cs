using AutoMapper;
using MarketPlace.Application.Orders.Commands;
using MarketPlace.Application.Orders.Models;
using MarketPlace.Application.Orders.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Infrastructure.Orders.CommandHandlers;

public class OrderItemCreateCommandHandler(
    IMapper mapper,
    IOrderItemService orderItemService) : ICommandHandler<OrderItemCreateCommand, OrderItemDto>
{
    public async Task<OrderItemDto> Handle(OrderItemCreateCommand request, CancellationToken cancellationToken)
    {
        var orderItem = mapper.Map<OrderItem>(request.OrderItemDto);

        var createdOrderItem = await orderItemService.CreateAsync(orderItem, cancellationToken: cancellationToken);

        return mapper.Map<OrderItemDto>(createdOrderItem);
    }
}
