using AutoMapper;
using MarketPlace.Application.Categories.Commands;
using MarketPlace.Application.Categories.Models;
using MarketPlace.Application.Categories.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Infrastructure.Categories.CommandHandlers;

public class CategoryCreateCommandHandler(
    IMapper mapper,
    ICategoryService categoryService) : ICommandHandler<CategoryCreateCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        var category = mapper.Map<Category>(request.CategoryDto);

        var createdCategory = await categoryService.CreateAsync(category, cancellationToken: cancellationToken);

        return mapper.Map<CategoryDto>(createdCategory);
    }
}
