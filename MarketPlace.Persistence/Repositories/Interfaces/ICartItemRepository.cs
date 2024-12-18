using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using System.Linq.Expressions;

namespace MarketPlace.Persistence.Repositories.Interfaces;

public interface ICartItemRepository
{
    IQueryable<CartItem> Get(
             Expression<Func<CartItem, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    ValueTask<CartItem?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<CartItem>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<CartItem> CreateAsync(
        CartItem cartItem,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<CartItem> UpdateAsync(
        CartItem cartItem,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<CartItem?> DeleteAsync(
        CartItem cartItem,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<CartItem?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}

