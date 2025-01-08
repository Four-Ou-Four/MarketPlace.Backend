using AutoMapper;
using MarketPlace.Application.Identity.Models;
using MarketPlace.Application.Identity.Queries;
using MarketPlace.Application.Identity.Services;
using MarketPlace.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Identity.QueryHandlers;

public class UserGetQueryHandler(
    IMapper mapper,
    IUserService userService)
    : IQueryHandler<UserGetQuery, ICollection<UserDto>>
{
    public async Task<ICollection<UserDto>> Handle(UserGetQuery request, CancellationToken cancellationToken)
    {
        var result = await userService.Get(
            request.UserFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<UserDto>>(result);
    }
}
