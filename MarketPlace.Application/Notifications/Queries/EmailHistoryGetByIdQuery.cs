using MarketPlace.Domain.Common.Queries;
using MarketPlace.Application.Notifications.Models;

namespace MarketPlace.Application.Notifications.Queries;

public class EmailHistoryGetByIdQuery : IQuery<EmailHistoryDto?>
{
    public Guid EmailHistoryId { get; set; }
}
