using MarketPlace.Domain.Common.Commands;
using MarketPlace.Application.Categories.Models;

namespace MarketPlace.Application.Categories.Commands;

public record CategoryCreateCommand : ICommand<CategoryDto>
{
    public CategoryDto CategoryDto { get; set; }
}
