using MarketPlace.Application.Answers.Models;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Application.Answers.Queries;

public class ProductGetQuery : IQuery<ICollection<ProductDto>>
{
    public ProductFilter ProductFilter { get; set; }
}
