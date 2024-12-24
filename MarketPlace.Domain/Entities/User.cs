using MarketPlace.Domain.Common.Entities;
using MarketPlace.Domain.Enums;

namespace MarketPlace.Domain.Entities;

public class User : AuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PasswordHash { get; set; }
    public int Age { get; set; }
    public bool IsEmailAddressVerified { get; set; }
    public Role Role { get; set; }
    public UserSettings? UserSettings { get; set; }
    public Cart Cart { get; set; }
    public IEnumerable<Product> Products { get; set; }
    public IEnumerable<OrderItem> Orders { get; set; }
    public IEnumerable<Comment> Comments { get; set; }
    public IEnumerable<Rating> Ratings { get; set; }
}
