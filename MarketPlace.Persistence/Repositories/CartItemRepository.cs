using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using MarketPlace.Persistence.Caching.Brokers;
using MarketPlace.Persistence.DataContexts;
using MarketPlace.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MarketPlace.Persistence.Repositories;

public class CartItemRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<CartItem, AppDbContext>(appDbContext, cacheBroker),
    ICartItemRepository

{
    public IQueryable<CartItem> Get(
        Expression<Func<CartItem, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<CartItem?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<CartItem>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<CartItem> CreateAsync(
        CartItem cartItem,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    base.CreateAsync(cartItem, commandOptions, cancellationToken);

    public ValueTask<CartItem> UpdateAsync(
        CartItem cartItem,
        CommandOptions commandOptions,
        CancellationToken cancellationToken) =>
    base.UpdateAsync(cartItem, commandOptions, cancellationToken);

    public ValueTask<CartItem?> DeleteAsync(
        CartItem cartItem,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.UpdateAsync(cartItem, commandOptions, cancellationToken);

    public ValueTask<CartItem?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
