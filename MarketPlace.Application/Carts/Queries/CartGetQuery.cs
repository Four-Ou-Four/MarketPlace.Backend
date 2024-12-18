using MarketPlace.Domain.Common.Queries;
using MarketPlace.Application.Carts.Models;

namespace MarketPlace.Application.Carts.Queries;

public record CartGetQuery : IQuery<ICollection<CartDto>>
{
    public CartFilter CartFilter { get; set; }
}
