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
    public IEnumerable<Product> Products { get; set; }
    public IEnumerable<Order> Orders { get; set; }
    public Cart Cart { get; set; }
}
