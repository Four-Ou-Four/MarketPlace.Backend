using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using System.Linq.Expressions;

namespace MarketPlace.Persistence.Repositories.Interfaces;

public interface ICommentRepository
{
    IQueryable<Comment> Get(
             Expression<Func<Comment, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    ValueTask<Comment?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<Comment>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Comment> CreateAsync(
        Comment comment,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Comment> UpdateAsync(
        Comment comment,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Comment?> DeleteAsync(
        Comment comment,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Comment?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
