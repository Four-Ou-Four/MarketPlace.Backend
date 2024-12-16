using MarketPlace.Domain.Common.Entities;

namespace MarketPlace.Domain.Entities;

public class Category : AuditableEntity
{
    public string Name { get; set; }
    public IEnumerable<Product> Products { get; set; }
}
