using AutoMapper;
using MarketPlace.Application.Identity.Commands;
using MarketPlace.Application.Identity.Models;
using MarketPlace.Application.Identity.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Infrastructure.Identity.CommandHandlers;

public class UserUpdateCommandHandler(
    IMapper mapper,
    IUserService userService) : ICommandHandler<UserUpdateCommand, UserDto>
{
    public async Task<UserDto> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request.UserDto);

        var updatedUser = await userService.UpdateAsync(user, cancellationToken: cancellationToken);

        return mapper.Map<UserDto>(updatedUser);
    }
}
