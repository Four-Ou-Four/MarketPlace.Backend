using MarketPlace.Domain.Common.Queries;
using MarketPlace.Application.Categories.Models;

namespace MarketPlace.Application.Categories.Queries;

public record CategoryGetByIdQuery : IQuery<CategoryDto?>
{
    public Guid CategoryId { get; set; }
}
