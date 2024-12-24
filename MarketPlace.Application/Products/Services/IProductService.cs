using MarketPlace.Application.Answers.Models;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using System.Linq.Expressions;

namespace MarketPlace.Application.Answers.Services;

public interface IProductService
{
    IQueryable<Product> Get(
             Expression<Func<Product, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    IQueryable<Product> Get(
        ProductFilter productFilter,
        QueryOptions queryOptions = default);

    ValueTask<Product?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<Product>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Product> CreateAsync(
        Product product,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Product> UpdateAsync(
        Product product,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Product?> DeleteAsync(
        Product product,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Product?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
