using MarketPlace.Application.Orders.Models;
using MarketPlace.Application.Orders.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using MarketPlace.Domain.Enums;
using MarketPlace.Infrastructure.Orders.Validators;
using MarketPlace.Persistence.Extensions;
using MarketPlace.Persistence.Repositories.Interfaces;
using FluentValidation;
using System.Linq.Expressions;

namespace MarketPlace.Infrastructure.Orders.Services;

public class OrderService(
    IOrderRepository orderRepository,
    OrderValidator validator)
   : IOrderService
{
    public IQueryable<Order> Get(
        Expression<Func<Order, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    orderRepository.Get(predicate, queryOptions);

    public IQueryable<Order> Get(
        OrderFilter orderFilter,
        QueryOptions queryOptions = default) =>
    orderRepository
        .Get(queryOptions: queryOptions)
        .ApplyPagination(orderFilter);

    public ValueTask<Order?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    orderRepository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Order>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    orderRepository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    orderRepository.CheckByIdAsync(id, cancellationToken);

    public async ValueTask<Order> CreateAsync(
        Order order,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            order, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await orderRepository.CreateAsync(order, commandOptions, cancellationToken);
    }

    public async ValueTask<Order> UpdateAsync(
        Order order,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            order, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await orderRepository.UpdateAsync(order, commandOptions, cancellationToken);
    }

    public ValueTask<Order?> DeleteAsync(
        Order order,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    orderRepository.DeleteAsync(order, commandOptions, cancellationToken);

    public ValueTask<Order?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    orderRepository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
