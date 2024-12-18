using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using MarketPlace.Application.Carts.Models;
using System.Linq.Expressions;

namespace MarketPlace.Application.Carts.Services;

public interface ICartService
{
    IQueryable<Cart> Get(
             Expression<Func<Cart, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    IQueryable<Cart> Get(
        CartFilter cartFilter,
        QueryOptions queryOptions = default);

    ValueTask<Cart?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<Cart>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Cart> CreateAsync(
        Cart cart,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Cart> UpdateAsync(
        Cart cart,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Cart?> DeleteAsync(
        Cart cart,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Cart?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
