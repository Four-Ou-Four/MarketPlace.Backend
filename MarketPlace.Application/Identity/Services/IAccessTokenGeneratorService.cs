using MarketPlace.Domain.Entities;

namespace MarketPlace.Application.Identity.Services;

public interface IAccessTokenGeneratorService
{
    AccessToken GetToken(User user);

    Guid GetTokenId(string accessToken);
}