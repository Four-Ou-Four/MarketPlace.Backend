using MarketPlace.Application.Answers.Models;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Answers.Commands;

public class ProductUpdateCommand : ICommand<ProductDto>
{
    public ProductDto ProductDto { get; set; }
}
