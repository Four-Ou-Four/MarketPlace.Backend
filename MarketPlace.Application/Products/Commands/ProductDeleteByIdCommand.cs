using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Products.Commands;

public class ProductDeleteByIdCommand : ICommand<bool>
{
    public Guid ProductId { get; set; }
}
