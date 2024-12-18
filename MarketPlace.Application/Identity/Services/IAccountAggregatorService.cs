using MarketPlace.Domain.Entities;

namespace MarketPlace.Application.Identity.Services;

public interface IAccountAggregatorService
{
    ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default);
}