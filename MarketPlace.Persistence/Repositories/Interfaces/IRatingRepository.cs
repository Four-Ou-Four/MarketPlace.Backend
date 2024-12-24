using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using System.Linq.Expressions;

namespace MarketPlace.Persistence.Repositories.Interfaces;

public interface IRatingRepository
{
    IQueryable<Rating> Get(
             Expression<Func<Rating, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    ValueTask<Rating?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<Rating>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Rating> CreateAsync(
        Rating rating,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Rating> UpdateAsync(
        Rating rating,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Rating?> DeleteAsync(
        Rating rating,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Rating?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
