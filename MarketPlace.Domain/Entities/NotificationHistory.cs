﻿using MarketPlace.Domain.Common.Entities;
using MarketPlace.Domain.Enums;

namespace MarketPlace.Domain.Entities;

public abstract class NotificationHistory : IEntity
{
    public Guid TemplateId { get; set; }

    public Guid SenderUserId { get; set; }

    public Guid ReceiverUserId { get; set; }

    public NotificationType Type { get; set; }

    public string Content { get; set; } = default!;

    public bool IsSuccessful { get; set; }

    public string? ErrorMessage { get; set; }

    public NotificationTemplate Template { get; set; }
    public Guid Id { get; set; }
}