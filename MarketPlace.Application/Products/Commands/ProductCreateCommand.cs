using MarketPlace.Application.Products.Models;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Products.Commands;

public record ProductCreateCommand : ICommand<ProductDto>
{
    public ProductDto ProductDto { get; set; }
}
