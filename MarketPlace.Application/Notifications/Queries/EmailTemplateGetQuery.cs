using MarketPlace.Application.Identity.Models;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Application.Notifications.Models;

namespace MarketPlace.Application.Notifications.Queries;

public class EmailTemplateGetQuery : IQuery<ICollection<EmailTemplateDto>>
{
    public EmailTemplateFilter EmailTemplateFilter { get; set; }
}
