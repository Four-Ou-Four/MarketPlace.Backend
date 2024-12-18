using MarketPlace.Domain.Common.Commands;
using MarketPlace.Application.Identity.Models;

namespace MarketPlace.Application.Identity.Commands;

public class UserUpdateCommand : ICommand<UserDto>
{
    public UserDto UserDto { get; set; }
}
