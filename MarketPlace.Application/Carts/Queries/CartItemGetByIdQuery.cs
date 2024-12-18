using MarketPlace.Application.Carts.Models;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Application.Carts.Queries;

public record CartItemGetByIdQuery : IQuery<CartItemDto?>
{
    public Guid CartItemId { get; set; }
}
