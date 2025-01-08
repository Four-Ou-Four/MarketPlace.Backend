using AutoMapper;
using MarketPlace.Application.Notifications.Events;
using MarketPlace.Application.Notifications.Models;

namespace MarketPlace.Infrastructure.Notifications.Mappers;

public class NotificationRequestMapper : Profile
{
    public NotificationRequestMapper()
    {
        CreateMap<ProcessNotificationEvent, EmailProcessNotificationEvent>();
    }
}