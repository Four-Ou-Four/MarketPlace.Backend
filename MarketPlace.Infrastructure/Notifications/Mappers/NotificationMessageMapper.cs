using AutoMapper;
using MarketPlace.Application.Notifications.Models;

namespace MarketPlace.Infrastructure.Notifications.Mappers;

public class NotificationMessageMapper : Profile
{
    public NotificationMessageMapper()
    {
        CreateMap<EmailProcessNotificationEvent, EmailMessage>();
    }
}