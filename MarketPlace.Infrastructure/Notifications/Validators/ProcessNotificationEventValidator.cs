using MarketPlace.Application.Notifications.Events;
using FluentValidation;

namespace MarketPlace.Infrastructure.Notifications.Validators;

public class ProcessNotificationEventValidator : AbstractValidator<ProcessNotificationEvent>
{
    public ProcessNotificationEventValidator()
    {
        RuleFor(history => history.ReceiverUserId).NotEqual(Guid.Empty);
    }
}