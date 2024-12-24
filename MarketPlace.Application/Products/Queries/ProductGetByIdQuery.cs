using MarketPlace.Application.Answers.Models;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Application.Answers.Queries;

public class ProductGetByIdQuery : IQuery<ProductDto?>
{
    public Guid ProductId { get; set; }
}
