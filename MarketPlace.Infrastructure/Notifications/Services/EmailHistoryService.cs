using MarketPlace.Application.Notifications.Models;
using MarketPlace.Application.Notifications.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using MarketPlace.Domain.Enums;
using MarketPlace.Persistence.Extensions;
using MarketPlace.Persistence.Repositories.Interfaces;
using FluentValidation;
using MarketPlace.Infrastructure.Notifications.Validators;
using System.Linq.Expressions;

namespace MarketPlace.Infrastructure.Notifications.Services;

public class EmailHistoryService(
    IEmailHistoryRepository emailHistoryRepository,
    EmailHistoryValidator emailHistoryValidator)
    : IEmailHistoryService
{
    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    emailHistoryRepository.CheckByIdAsync(id, cancellationToken);

    public IQueryable<EmailHistory> Get(
        Expression<Func<EmailHistory, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    emailHistoryRepository.Get(predicate, queryOptions);

    public IQueryable<EmailHistory> Get(
        EmailHistoryFilter emailHistoryFilter,
        QueryOptions queryOptions = default) =>
    emailHistoryRepository.
        Get(queryOptions: queryOptions)
        .ApplyPagination(emailHistoryFilter);

    public ValueTask<EmailHistory?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    emailHistoryRepository.GetByIdAsync(id, queryOptions);

    public ValueTask<IList<EmailHistory>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    emailHistoryRepository.GetByIdsAsync(ids, queryOptions);

    public async ValueTask<EmailHistory> CreateAsync(
        EmailHistory emailHistory,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await emailHistoryValidator.ValidateAsync(
            emailHistory,
            options => options.IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken
        );
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        return await emailHistoryRepository.CreateAsync(emailHistory, commandOptions, cancellationToken);
    }
}
