using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using MarketPlace.Persistence.Caching.Brokers;
using MarketPlace.Persistence.DataContexts;
using MarketPlace.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MarketPlace.Persistence.Repositories;

public class OrderRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<Order, AppDbContext>(appDbContext, cacheBroker),
    IOrderRepository

{
    public IQueryable<Order> Get(
        Expression<Func<Order, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<Order?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Order>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Order> CreateAsync(
        Order order,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    base.CreateAsync(order, commandOptions, cancellationToken);

    public ValueTask<Order> UpdateAsync(
        Order order,
        CommandOptions commandOptions,
        CancellationToken cancellationToken) =>
    base.UpdateAsync(order, commandOptions, cancellationToken);

    public ValueTask<Order?> DeleteAsync(
        Order order,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.UpdateAsync(order, commandOptions, cancellationToken);

    public ValueTask<Order?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
