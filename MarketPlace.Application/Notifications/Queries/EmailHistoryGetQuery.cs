using MarketPlace.Domain.Common.Queries;
using MarketPlace.Application.Notifications.Models;

namespace MarketPlace.Application.Notifications.Queries;

public class EmailHistoryGetQuery : IQuery<ICollection<EmailHistoryDto>>
{
    public EmailHistoryFilter EmailHistoryFilter { get; set; }
}
