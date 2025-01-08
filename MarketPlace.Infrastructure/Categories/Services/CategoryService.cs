using MarketPlace.Application.Categories.Models;
using MarketPlace.Application.Categories.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using MarketPlace.Domain.Enums;
using MarketPlace.Persistence.Extensions;
using MarketPlace.Persistence.Repositories.Interfaces;
using FluentValidation;
using MarketPlace.Infrastructure.Categories.Validators;
using System.Linq.Expressions;

namespace MarketPlace.Infrastructure.Categories.Services;

public class CategoryService(
    ICategoryRepository categoryRepository,
    CategoryValidator validator)
   : ICategoryService
{
    public IQueryable<Category> Get(
        Expression<Func<Category, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    categoryRepository.Get(predicate, queryOptions);

    public IQueryable<Category> Get(
        CategoryFilter categoryFilter,
        QueryOptions queryOptions = default) =>
    categoryRepository
        .Get(queryOptions: queryOptions)
        .ApplyPagination(categoryFilter);

    public ValueTask<Category?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    categoryRepository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Category>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    categoryRepository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    categoryRepository.CheckByIdAsync(id, cancellationToken);

    public async ValueTask<Category> CreateAsync(
        Category category,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            category,
            options => options
            .IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await categoryRepository.CreateAsync(category, commandOptions, cancellationToken);
    }

    public async ValueTask<Category> UpdateAsync(
        Category category,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            category,
            options => options
            .IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await categoryRepository.UpdateAsync(category, commandOptions, cancellationToken);
    }

    public ValueTask<Category?> DeleteAsync(
        Category category,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    categoryRepository.DeleteAsync(category, commandOptions, cancellationToken);

    public ValueTask<Category?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    categoryRepository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
