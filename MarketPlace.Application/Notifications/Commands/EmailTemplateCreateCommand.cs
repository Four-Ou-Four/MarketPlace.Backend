using MarketPlace.Domain.Common.Commands;
using MarketPlace.Application.Notifications.Models;

namespace MarketPlace.Application.Notifications.Commands;

public class EmailTemplateCreateCommand : ICommand<EmailTemplateDto>
{
    public EmailTemplateDto EmailTemplateDto { get; set; }
}
