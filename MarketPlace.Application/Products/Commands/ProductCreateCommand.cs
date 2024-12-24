using MarketPlace.Application.Answers.Models;
using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Answers.Commands;

public record ProductCreateCommand : ICommand<ProductDto>
{
    public ProductDto ProductDto { get; set; }
}
