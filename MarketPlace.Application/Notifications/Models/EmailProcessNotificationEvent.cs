using MarketPlace.Domain.Enums;
using MarketPlace.Application.Notifications.Events;

namespace MarketPlace.Application.Notifications.Models;

public record EmailProcessNotificationEvent : ProcessNotificationEvent
{
    public EmailProcessNotificationEvent()
    {
        Type = NotificationType.Email;
    }
}