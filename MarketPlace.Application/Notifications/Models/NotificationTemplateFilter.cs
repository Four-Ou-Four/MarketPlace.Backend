using MarketPlace.Domain.Enums;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Application.Notifications.Models;

public class NotificationTemplateFilter : FilterPagination
{
    public IList<NotificationType> TemplateType { get; set; }
}