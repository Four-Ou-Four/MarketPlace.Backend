using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using MarketPlace.Application.Identity.Models;
using System.Linq.Expressions;

namespace MarketPlace.Application.Identity.Services;

public interface IUserService
{
    IQueryable<User> Get(
             Expression<Func<User, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    IQueryable<User> Get(
        UserFilter userFilter,
        QueryOptions queryOptions = default);

    ValueTask<User?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<User>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    Task<Guid?> GetIdByEmailAddressAsync(
        string emailAddress,
        CancellationToken cancellationToken = default);

    ValueTask<User> GetSystemUserAsync(
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(
        User user,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<User> UpdateAsync(
        User user,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<User?> DeleteAsync(
        User user,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<User?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
