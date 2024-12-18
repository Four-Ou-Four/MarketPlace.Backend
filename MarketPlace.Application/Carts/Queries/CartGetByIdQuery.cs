using MarketPlace.Domain.Common.Queries;
using MarketPlace.Application.Carts.Models;

namespace MarketPlace.Application.Carts.Queries;

public record CartGetByIdQuery : IQuery<CartDto?>
{
    public Guid CartId { get; set; }
}
