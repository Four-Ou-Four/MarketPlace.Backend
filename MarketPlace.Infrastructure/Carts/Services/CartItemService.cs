using MarketPlace.Application.Carts.Models;
using MarketPlace.Application.Carts.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using MarketPlace.Domain.Enums;
using MarketPlace.Infrastructure.Carts.Validators;
using MarketPlace.Persistence.Extensions;
using MarketPlace.Persistence.Repositories.Interfaces;
using FluentValidation;
using System.Linq.Expressions;

namespace MarketPlace.Infrastructure.Carts.Services;

public class CartItemService(
    ICartItemRepository cartItemRepository,
    CartItemValidator validator)
   : ICartItemService
{
    public IQueryable<CartItem> Get(
        Expression<Func<CartItem, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    cartItemRepository.Get(predicate, queryOptions);

    public IQueryable<CartItem> Get(
        CartItemFilter cartItemFilter,
        QueryOptions queryOptions = default) =>
    cartItemRepository
        .Get(queryOptions: queryOptions)
        .ApplyPagination(cartItemFilter);

    public ValueTask<CartItem?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    cartItemRepository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<CartItem>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    cartItemRepository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    cartItemRepository.CheckByIdAsync(id, cancellationToken);

    public async ValueTask<CartItem> CreateAsync(
        CartItem cartItem,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            cartItem,
            options => options
            .IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await cartItemRepository.CreateAsync(cartItem, commandOptions, cancellationToken);
    }

    public async ValueTask<CartItem> UpdateAsync(
        CartItem cartItem,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            cartItem,
            options => options
            .IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await cartItemRepository.UpdateAsync(cartItem, commandOptions, cancellationToken);
    }

    public ValueTask<CartItem?> DeleteAsync(
        CartItem cartItem,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    cartItemRepository.DeleteAsync(cartItem, commandOptions, cancellationToken);

    public ValueTask<CartItem?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    cartItemRepository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
