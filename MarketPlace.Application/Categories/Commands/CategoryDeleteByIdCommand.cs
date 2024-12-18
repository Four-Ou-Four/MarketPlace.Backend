using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Categories.Commands;

public record CategoryDeleteByIdCommand : ICommand<bool>
{
    public Guid CategoryId { get; set; }
}
