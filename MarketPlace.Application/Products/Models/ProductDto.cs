namespace MarketPlace.Application.Answers.Models;

public class ProductDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
}
