using MarketPlace.Domain.Common.Events;

namespace MarketPlace.Application.Notifications.Events;

public record NotificationEvent : EventBase
{
    public Guid SenderUserId { get; set; }

    public Guid ReceiverUserId { get; set; }
}
