using MarketPlace.Application.Orders.Models;
using MarketPlace.Application.Orders.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using MarketPlace.Domain.Enums;
using MarketPlace.Persistence.Extensions;
using MarketPlace.Persistence.Repositories.Interfaces;
using FluentValidation;
using MarketPlace.Infrastructure.Orders.Validators;
using System.Linq.Expressions;

namespace MarketPlace.Infrastructure.Orders.Services;

public class OrderItemService(
    IOrderItemRepository orderItemRepository,
    OrderItemValidator validator)
   : IOrderItemService
{
    public IQueryable<OrderItem> Get(
        Expression<Func<OrderItem, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    orderItemRepository.Get(predicate, queryOptions);

    public IQueryable<OrderItem> Get(
        OrderItemFilter orderItemFilter,
        QueryOptions queryOptions = default) =>
    orderItemRepository
        .Get(queryOptions: queryOptions)
        .ApplyPagination(orderItemFilter);

    public ValueTask<OrderItem?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    orderItemRepository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<OrderItem>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    orderItemRepository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    orderItemRepository.CheckByIdAsync(id, cancellationToken);

    public async ValueTask<OrderItem> CreateAsync(
        OrderItem orderItem,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            orderItem,
            options => options
            .IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await orderItemRepository.CreateAsync(orderItem, commandOptions, cancellationToken);
    }

    public async ValueTask<OrderItem> UpdateAsync(
        OrderItem orderItem,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            orderItem,
            options => options
            .IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await orderItemRepository.UpdateAsync(orderItem, commandOptions, cancellationToken);
    }

    public ValueTask<OrderItem?> DeleteAsync(
        OrderItem orderItem,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    orderItemRepository.DeleteAsync(orderItem, commandOptions, cancellationToken);

    public ValueTask<OrderItem?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    orderItemRepository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
