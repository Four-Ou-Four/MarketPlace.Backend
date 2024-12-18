using MarketPlace.Domain.Common.Queries;
using MarketPlace.Application.Notifications.Models;

namespace MarketPlace.Application.Notifications.Queries;

public class EmailTemplateGetByIdQuery : IQuery<EmailTemplateDto?>
{
    public Guid EmailTemplateId { get; set; }
}
