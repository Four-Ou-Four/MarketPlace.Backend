using AutoMapper;
using MarketPlace.Application.Identity.Models;
using MarketPlace.Application.Identity.Queries;
using MarketPlace.Application.Identity.Services;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Infrastructure.Identity.QueryHandlers;

public class UserGetByIdQueryHandler(
    IMapper mapper,
    IUserService userService)
    : IQueryHandler<UserGetByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await userService.GetByIdAsync(request.UserId, cancellationToken: cancellationToken);

        return mapper.Map<UserDto>(result);
    }
}
