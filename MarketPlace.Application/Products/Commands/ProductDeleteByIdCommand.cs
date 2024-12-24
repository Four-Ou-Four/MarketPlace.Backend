using MarketPlace.Domain.Common.Commands;

namespace MarketPlace.Application.Answers.Commands;

public class ProductDeleteByIdCommand : ICommand<bool>
{
    public Guid ProductId { get; set; }
}
