using AutoMapper;
using MarketPlace.Application.Orders.Commands;
using MarketPlace.Application.Orders.Models;
using MarketPlace.Application.Orders.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Infrastructure.Orders.CommandHandlers;

public class OrderItemUpdateCommandHandler(
    IMapper mapper,
    IOrderItemService orderItemService) : ICommandHandler<OrderItemUpdateCommand, OrderItemDto>
{
    public async Task<OrderItemDto> Handle(OrderItemUpdateCommand request, CancellationToken cancellationToken)
    {
        var orderItem = mapper.Map<OrderItem>(request.OrderItemDto);

        var createdOrderItem = await orderItemService.UpdateAsync(orderItem, cancellationToken: cancellationToken);

        return mapper.Map<OrderItemDto>(createdOrderItem);
    }
}
