using AutoMapper;
using MarketPlace.Application.Categories.Commands;
using MarketPlace.Application.Categories.Models;
using MarketPlace.Application.Categories.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Infrastructure.Categories.CommandHandlers;

public class CategoryUpdateCommandHandler(
    IMapper mapper,
    ICategoryService categoryService) : ICommandHandler<CategoryUpdateCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
    {
        var category = mapper.Map<Category>(request.CategoryDto);

        var createdCategory = await categoryService.UpdateAsync(category, cancellationToken: cancellationToken);

        return mapper.Map<CategoryDto>(createdCategory);
    }
}
