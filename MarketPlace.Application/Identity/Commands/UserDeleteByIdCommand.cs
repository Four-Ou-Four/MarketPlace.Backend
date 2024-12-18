using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Identity.Commands;

public class UserDeleteByIdCommand : ICommand<bool>
{
    public Guid UserId { get; set; }
}
