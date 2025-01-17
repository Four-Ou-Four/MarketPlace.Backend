using MarketPlace.Application.Orders.Commands;
using MarketPlace.Application.Orders.Services;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Infrastructure.Orders.CommandHandlers;

public class OrderItemDeleteByIdCommandHandler(
    IOrderItemService orderItemService)
    : ICommandHandler<OrderItemDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(OrderItemDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await orderItemService.DeleteByIdAsync(request.OrderItemId, cancellationToken: cancellationToken);

        return result is not null;
    }
}