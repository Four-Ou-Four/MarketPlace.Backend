using MarketPlace.Application.Orders.Models;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using System.Linq.Expressions;

namespace MarketPlace.Application.Orders.Services;

public interface IOrderItemService
{
    IQueryable<OrderItem> Get(
             Expression<Func<OrderItem, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    IQueryable<OrderItem> Get(
        OrderItemFilter orderItemFilter,
        QueryOptions queryOptions = default);

    ValueTask<OrderItem?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<OrderItem>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<OrderItem> CreateAsync(
        OrderItem orderItem,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<OrderItem> UpdateAsync(
        OrderItem orderItem,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<OrderItem?> DeleteAsync(
        OrderItem orderItem,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<OrderItem?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
