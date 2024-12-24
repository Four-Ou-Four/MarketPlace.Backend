using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using MarketPlace.Persistence.Caching.Brokers;
using MarketPlace.Persistence.DataContexts;
using MarketPlace.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MarketPlace.Persistence.Repositories;

public class RatingRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<Rating, AppDbContext>(appDbContext, cacheBroker),
    IRatingRepository

{
    public IQueryable<Rating> Get(
        Expression<Func<Rating, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<Rating?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Rating>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Rating> CreateAsync(
        Rating rating,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    base.CreateAsync(rating, commandOptions, cancellationToken);

    public ValueTask<Rating> UpdateAsync(
        Rating rating,
        CommandOptions commandOptions,
        CancellationToken cancellationToken) =>
    base.UpdateAsync(rating, commandOptions, cancellationToken);

    public ValueTask<Rating?> DeleteAsync(
        Rating rating,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.UpdateAsync(rating, commandOptions, cancellationToken);

    public ValueTask<Rating?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
