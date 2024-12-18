using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using System.Linq.Expressions;

namespace MarketPlace.Persistence.Repositories.Interfaces;

public interface IOrderRepository
{
    IQueryable<Order> Get(
             Expression<Func<Order, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    ValueTask<Order?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<Order>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Order> CreateAsync(
        Order order,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Order> UpdateAsync(
        Order order,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Order?> DeleteAsync(
        Order order,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Order?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}

