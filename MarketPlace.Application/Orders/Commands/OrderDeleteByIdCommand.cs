using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Orders.Commands;

public class OrderDeleteByIdCommand : ICommand<bool>
{
    public Guid OrderId { get; set; }
}
