using MarketPlace.Domain.Common.Queries;
using MarketPlace.Application.Identity.Models;

namespace MarketPlace.Application.Identity.Queries;

public class UserGetByIdQuery : IQuery<UserDto?>
{
    public Guid UserId { get; set; }
}
