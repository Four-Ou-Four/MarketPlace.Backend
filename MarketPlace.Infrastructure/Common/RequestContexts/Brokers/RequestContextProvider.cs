using MarketPlace.Domain.Brokers;
using MarketPlace.Domain.Constants;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.Infrastructure.Common.RequestContexts.Brokers;

public class RequestContextProvider(IHttpContextAccessor httpContextAccessor) : IRequestContextProvider
{
    public Guid GetUserId()
    {
        if (!IsLoggedIn())
            throw new InvalidOperationException("User is not logged in");

        var httpContext = httpContextAccessor.HttpContext;
        var userIdClaim = httpContext!.User.Claims.First(claim => claim.Type == ClaimConstants.UserId).Value;

        return Guid.Parse(userIdClaim);
    }

    public string? GetAccessToken()
    {
        return httpContextAccessor.HttpContext?.Request.Headers.Authorization;
    }

    public bool IsLoggedIn()
    {
        return httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
    }
}
