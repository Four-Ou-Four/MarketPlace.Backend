using MarketPlace.Domain.Enums;

namespace MarketPlace.Application.Notifications.Models;

public class EmailTemplateDto
{
    public Guid? Id { get; set; }
    public NotificationType Type { get; set; }
    public NotificationTemplateType TemplateType { get; set; }
    public string Content { get; set; } = default!;
    public string Subject { get; set; } = default!;
}
