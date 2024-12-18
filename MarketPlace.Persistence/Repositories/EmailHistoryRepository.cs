using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using MarketPlace.Persistence.Caching.Brokers;
using MarketPlace.Persistence.DataContexts;
using MarketPlace.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MarketPlace.Persistence.Repositories;

public class EmailHistoryRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<EmailHistory, AppDbContext>(appDbContext, cacheBroker),
    IEmailHistoryRepository

{
    public IQueryable<EmailHistory> Get(
        Expression<Func<EmailHistory, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<EmailHistory?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<EmailHistory>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<EmailHistory> CreateAsync(
        EmailHistory emailHistory,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    base.CreateAsync(emailHistory, commandOptions, cancellationToken);
}

