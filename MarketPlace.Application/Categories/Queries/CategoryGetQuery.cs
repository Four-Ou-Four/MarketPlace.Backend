using MarketPlace.Domain.Common.Queries;
using MarketPlace.Application.Categories.Models;

namespace MarketPlace.Application.Categories.Queries;

public record CategoryGetQuery : IQuery<ICollection<CategoryDto>>
{
    public CategoryFilter CategoryFilter { get; set; }
}
