using MarketPlace.Domain.Common.Commands;
using MarketPlace.Application.Categories.Models;

namespace MarketPlace.Application.Categories.Commands;

public record CategoryUpdateCommand : ICommand<CategoryDto>
{
    public CategoryDto CategoryrDto { get; set; }
}
