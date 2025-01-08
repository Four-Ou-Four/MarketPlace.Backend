using AutoMapper;
using MarketPlace.Application.Common.EventBus.Brokers;
using MarketPlace.Application.Common.Settings;
using MarketPlace.Application.Notifications.Events;
using MarketPlace.Application.Notifications.Models;
using MarketPlace.Application.Notifications.Services;
using MarketPlace.Domain.Common.Events;
using MarketPlace.Domain.Entities;
using MarketPlace.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MarketPlace.Infrastructure.Notifications.EventHandlers;

public class RenderNotificationEventHandler(
    IServiceScopeFactory serviceScopeFactory,
    IOptions<NotificationSubscriberSettings> notificationSubscriberSettings,
    IEventBusBroker eventBusBroker,
    IOptions<NotificationSettings> notificationSettings) : EventHandlerBase<RenderNotificationEvent>
{
    protected override async ValueTask HandleAsync(RenderNotificationEvent @event, CancellationToken cancellationToken)
    {
        await using var scope = serviceScopeFactory.CreateAsyncScope();
        var emailRenderingService = scope.ServiceProvider.GetService<IEmailRenderingService>();

        if (@event.Template.Type == NotificationType.Email)
        {
            var emailMessage = new EmailMessage()
            {
                SenderEmailAddress = @event.SenderUser.EmailAddress,
                ReceiverEmailAddress = @event.ReceiverUser.EmailAddress,
                Template = (EmailTemplate)@event.Template,
                Variables = @event.Variables
            };

            await emailRenderingService.RenderAsync(emailMessage, cancellationToken);

            var sendNotificationEvent = new SendNotificationEvent
            {
                SenderUserId = @event.SenderUserId,
                ReceiverUserId = @event.ReceiverUserId,
                Message = emailMessage,
            };

            await eventBusBroker.PublishAsync(
               sendNotificationEvent,
               cancellationToken
           );
        }
    }
}
