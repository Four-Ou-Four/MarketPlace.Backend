namespace MarketPlace.Application.Orders.Models;

public class OrderDto
{
    public Guid? Id { get; set; }
    public DateTime OrderDate { get; set; }
    public Guid UserId { get; set; }
}
