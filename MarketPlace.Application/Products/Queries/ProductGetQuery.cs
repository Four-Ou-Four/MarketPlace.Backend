using MarketPlace.Application.Products.Models;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Application.Products.Queries;

public class ProductGetQuery : IQuery<ICollection<ProductDto>>
{
    public ProductFilter ProductFilter { get; set; }
}
