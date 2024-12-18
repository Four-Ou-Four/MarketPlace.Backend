using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using MarketPlace.Persistence.Caching.Brokers;
using MarketPlace.Persistence.DataContexts;
using MarketPlace.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MarketPlace.Persistence.Repositories;

public class OrderItemRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<OrderItem, AppDbContext>(appDbContext, cacheBroker),
    IOrderItemRepository

{
    public IQueryable<OrderItem> Get(
        Expression<Func<OrderItem, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<OrderItem?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<OrderItem>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<OrderItem> CreateAsync(
        OrderItem orderItem,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    base.CreateAsync(orderItem, commandOptions, cancellationToken);

    public ValueTask<OrderItem> UpdateAsync(
        OrderItem orderItem,
        CommandOptions commandOptions,
        CancellationToken cancellationToken) =>
    base.UpdateAsync(orderItem, commandOptions, cancellationToken);

    public ValueTask<OrderItem?> DeleteAsync(
        OrderItem orderItem,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.UpdateAsync(orderItem, commandOptions, cancellationToken);

    public ValueTask<OrderItem?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
