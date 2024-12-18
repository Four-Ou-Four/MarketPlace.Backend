using MarketPlace.Application.Notifications.Models;

namespace MarketPlace.Application.Notifications.Brokers;

public interface IEmailSenderBroker
{
    ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}