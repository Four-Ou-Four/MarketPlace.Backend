using MarketPlace.Domain.Common.Exceptions;
using MarketPlace.Application.Notifications.Models;

namespace MarketPlace.Application.Notifications.Services;

public interface IEmailOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(EmailProcessNotificationEvent @event, CancellationToken cancellationToken = default);
}
