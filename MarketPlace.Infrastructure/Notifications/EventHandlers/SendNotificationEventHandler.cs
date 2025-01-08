using AutoMapper;
using MarketPlace.Application.Common.EventBus.Brokers;
using MarketPlace.Application.Common.Settings;
using MarketPlace.Application.Notifications.Events;
using MarketPlace.Application.Notifications.Models;
using MarketPlace.Application.Notifications.Services;
using MarketPlace.Domain.Common.Events;
using MarketPlace.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MarketPlace.Infrastructure.Notifications.EventHandlers;

public class SendNotificationEventHandler(
    IServiceScopeFactory serviceScopeFactory,
    IMapper mapper,
    IOptions<NotificationSubscriberSettings> notificationSubscriberSettings,
    IEventBusBroker eventBusBroker,
    IOptions<NotificationSettings> notificationSettings
) : EventHandlerBase<SendNotificationEvent>
{
    protected override async ValueTask HandleAsync(SendNotificationEvent @event, CancellationToken cancellationToken)
    {
        await using var scope = serviceScopeFactory.CreateAsyncScope();
        var emailSenderService = scope.ServiceProvider.GetRequiredService<IEmailSenderService>();
        var emailHistoryService = scope.ServiceProvider.GetRequiredService<IEmailHistoryService>();

        if (@event.Message is EmailMessage emailMessage)
        {
            await emailSenderService.SendAsync(emailMessage, cancellationToken);

            var history = mapper.Map<EmailHistory>(emailMessage);
            history.SenderUserId = @event.SenderUserId;
            history.ReceiverUserId = @event.ReceiverUserId;

            Console.WriteLine($"TEMPLATE YES?: {history.TemplateId}");

            //await emailHistoryService.CreateAsync(history, cancellationToken: cancellationToken);

            if (!history.IsSuccessful) throw new InvalidOperationException("Email history is not created");
        }
    }
}
