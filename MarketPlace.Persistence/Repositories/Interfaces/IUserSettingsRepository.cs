using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Persistence.Repositories.Interfaces;

public interface IUserSettingsRepository
{
    ValueTask<UserSettings?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<UserSettings> CreateAsync(
        UserSettings userSettings,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

}