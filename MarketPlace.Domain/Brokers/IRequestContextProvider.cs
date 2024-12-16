namespace MarketPlace.Domain.Brokers;

public interface IRequestContextProvider
{
    Guid GetUserId();
    string? GetAccessToken();
    bool IsLoggedIn();
}
