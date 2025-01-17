using MarketPlace.Application.Orders.Commands;
using MarketPlace.Application.Orders.Services;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Infrastructure.Orders.CommandHandlers;

public class OrderDeleteByIdCommandHandler(
    IOrderService orderService)
    : ICommandHandler<OrderDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(OrderDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await orderService.DeleteByIdAsync(request.OrderId, cancellationToken: cancellationToken);

        return result is not null;
    }
}