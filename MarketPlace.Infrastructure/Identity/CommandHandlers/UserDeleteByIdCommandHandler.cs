using MarketPlace.Application.Identity.Commands;
using MarketPlace.Application.Identity.Services;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Infrastructure.Identity.CommandHandlers;

public class UserDeleteByIdCommandHandler(
    IUserService userService)
    : ICommandHandler<UserDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(UserDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await userService.DeleteByIdAsync(request.UserId, cancellationToken: cancellationToken);

        return result is not null;
    }
}
