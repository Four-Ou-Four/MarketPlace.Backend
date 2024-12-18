using MarketPlace.Domain.Common.Exceptions;
using MarketPlace.Domain.Entities;
using MarketPlace.Application.Notifications.Events;
using MarketPlace.Application.Notifications.Models;

namespace MarketPlace.Application.Notifications.Services;

public interface INotificationAggregatorService
{
    public ValueTask<FuncResult<bool>> SendAsync(ProcessNotificationEvent processNotificationEvent, CancellationToken cancellationToken = default);

    public ValueTask<IList<NotificationTemplate>> GetTemplatesByFilterAsync(
        NotificationTemplateFilter notificationTemplateFilter,
        CancellationToken cancellationToken = default
        );
}
