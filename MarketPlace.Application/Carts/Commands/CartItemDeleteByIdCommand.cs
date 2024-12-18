using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Carts.Commands;

public record CartItemDeleteByIdCommand : ICommand<bool>
{
    public Guid CartItemId { get; set; }
}
