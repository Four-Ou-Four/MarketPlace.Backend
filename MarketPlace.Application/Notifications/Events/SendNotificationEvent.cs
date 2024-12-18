using MarketPlace.Application.Notifications.Models;

namespace MarketPlace.Application.Notifications.Events;

public record SendNotificationEvent : NotificationEvent
{
    public NotificationMessage Message { get; set; } = default!;
}
