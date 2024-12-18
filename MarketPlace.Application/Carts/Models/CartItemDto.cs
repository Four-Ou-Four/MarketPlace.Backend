namespace MarketPlace.Application.Carts.Models;

public class CartItemDto
{
    public Guid? Id { get; set; }
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
