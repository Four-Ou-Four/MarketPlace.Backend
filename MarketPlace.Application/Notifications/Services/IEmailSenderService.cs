using MarketPlace.Application.Notifications.Models;

namespace MarketPlace.Application.Notifications.Services;

public interface IEmailSenderService
{
    ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}
