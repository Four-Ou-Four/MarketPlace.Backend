using MarketPlace.Domain.Common.Queries;
using MarketPlace.Application.Identity.Models;

namespace MarketPlace.Application.Identity.Queries;

public class UserGetQuery : IQuery<ICollection<UserDto>>
{
    public UserFilter UserFilter { get; set; }
}
