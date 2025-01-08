using MarketPlace.Application.Products.Models;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Products.Commands;

public class ProductUpdateCommand : ICommand<ProductDto>
{
    public ProductDto ProductDto { get; set; }
}
