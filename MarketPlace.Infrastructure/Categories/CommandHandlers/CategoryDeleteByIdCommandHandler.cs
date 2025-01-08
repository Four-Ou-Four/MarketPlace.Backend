using MarketPlace.Application.Categories.Commands;
using MarketPlace.Application.Categories.Services;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Infrastructure.Categories.CommandHandlers;

public class CategoryDeleteByIdCommandHandler(
    ICategoryService categoryService)
    : ICommandHandler<CategoryDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(CategoryDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await categoryService.DeleteByIdAsync(request.CategoryId, cancellationToken: cancellationToken);

        return result is not null;
    }
}