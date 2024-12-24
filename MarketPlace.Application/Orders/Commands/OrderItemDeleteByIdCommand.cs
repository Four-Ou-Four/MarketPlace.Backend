using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Orders.Commands;

public class OrderItemDeleteByIdCommand : ICommand<bool>
{
    public Guid OrderItemId { get; set; }
}
