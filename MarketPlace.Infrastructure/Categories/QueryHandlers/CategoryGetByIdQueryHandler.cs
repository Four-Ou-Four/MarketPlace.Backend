using AutoMapper;
using MarketPlace.Application.Categories.Models;
using MarketPlace.Application.Categories.Queries;
using MarketPlace.Application.Categories.Services;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Infrastructure.Categories.QueryHandlers;

public class CategoryGetByIdQueryHandler(
    IMapper mapper,
    ICategoryService categoryService)
    : IQueryHandler<CategoryGetByIdQuery, CategoryDto>
{
    public async Task<CategoryDto> Handle(CategoryGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await categoryService.GetByIdAsync(request.CategoryId, cancellationToken: cancellationToken);

        return mapper.Map<CategoryDto>(result);
    }
}
