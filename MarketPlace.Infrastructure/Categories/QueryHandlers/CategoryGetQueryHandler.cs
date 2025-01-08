using AutoMapper;
using MarketPlace.Application.Categories.Models;
using MarketPlace.Application.Categories.Queries;
using MarketPlace.Application.Categories.Services;
using MarketPlace.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Categories.QueryHandlers;

public class CategoryGetQueryHandler(
    IMapper mapper,
    ICategoryService categoryService)
    : IQueryHandler<CategoryGetQuery, ICollection<CategoryDto>>
{
    public async Task<ICollection<CategoryDto>> Handle(CategoryGetQuery request, CancellationToken cancellationToken)
    {
        var result = await categoryService.Get(
            request.CategoryFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<CategoryDto>>(result);
    }
}
