using MarketPlace.Application.Carts.Models;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Application.Carts.Queries;

public record CartItemGetQuery : IQuery<ICollection<CartItemDto>>
{
    public CartItemFilter CartItemFilter { get; set; }
}
