using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using MarketPlace.Persistence.Caching.Brokers;
using MarketPlace.Persistence.DataContexts;
using MarketPlace.Persistence.Repositories.Interfaces;

namespace MarketPlace.Persistence.Repositories;

public class UserSettingsRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<UserSettings, AppDbContext>(appDbContext, cacheBroker),
    IUserSettingsRepository

{
    public ValueTask<UserSettings?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<UserSettings> CreateAsync(
        UserSettings userSettings,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    base.CreateAsync(userSettings, commandOptions, cancellationToken);
}
