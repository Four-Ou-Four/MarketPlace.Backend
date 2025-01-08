using MarketPlace.Application.Products.Models;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Application.Products.Queries;

public class ProductGetByIdQuery : IQuery<ProductDto?>
{
    public Guid ProductId { get; set; }
}
