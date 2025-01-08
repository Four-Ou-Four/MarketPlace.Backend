using MarketPlace.Application.Carts.Models;
using MarketPlace.Application.Carts.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using MarketPlace.Domain.Enums;
using MarketPlace.Persistence.Extensions;
using MarketPlace.Persistence.Repositories.Interfaces;
using FluentValidation;
using MarketPlace.Infrastructure.Carts.Validators;
using System.Linq.Expressions;
using MarketPlace.Persistence.Repositories;

namespace MarketPlace.Infrastructure.Carts.Services;

public class CartService(
    ICartRepository cartRepository,
    CartValidator validator)
   : ICartService
{
    public IQueryable<Cart> Get(
        Expression<Func<Cart, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    cartRepository.Get(predicate, queryOptions);

    public IQueryable<Cart> Get(
        CartFilter cartFilter,
        QueryOptions queryOptions = default) =>
    cartRepository
        .Get(queryOptions: queryOptions)
        .ApplyPagination(cartFilter);

    public ValueTask<Cart?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    cartRepository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Cart>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    cartRepository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    cartRepository.CheckByIdAsync(id, cancellationToken);

    public async ValueTask<Cart> CreateAsync(
        Cart cart,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            cart,
            options => options
            .IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await cartRepository.CreateAsync(cart, commandOptions, cancellationToken);
    }

    public async ValueTask<Cart> UpdateAsync(
        Cart cart,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            cart,
            options => options
            .IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await cartRepository.UpdateAsync(cart, commandOptions, cancellationToken);
    }

    public ValueTask<Cart?> DeleteAsync(
        Cart cart,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    cartRepository.DeleteAsync(cart, commandOptions, cancellationToken);

    public ValueTask<Cart?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    cartRepository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
