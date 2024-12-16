using MarketPlace.Domain.Common.Entities;
using MarketPlace.Domain.Enums;

namespace MarketPlace.Domain.Entities;

public class UserSettings : IEntity
{
    public NotificationType? PreferredNotificationType { get; set; }

    /// <summary>
    ///     Gets or sets the user Id
    /// </summary>
    public Guid Id { get; set; }
}