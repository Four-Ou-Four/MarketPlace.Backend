using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Carts.Commands;

public record CartDeleteByIdCommand : ICommand<bool>
{
    public Guid CartId { get; set; }
}
