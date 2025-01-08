using AutoMapper;
using MarketPlace.Application.Notifications.Models;
using MarketPlace.Application.Notifications.Queries;
using MarketPlace.Application.Notifications.Services;
using MarketPlace.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Notifications.QueryHandlers;

public class EmailHistoryGetQueryHandler(
    IMapper mapper,
    IEmailHistoryService emailHistoryService)
    : IQueryHandler<EmailHistoryGetQuery, ICollection<EmailHistoryDto>>
{
    public async Task<ICollection<EmailHistoryDto>> Handle(EmailHistoryGetQuery request, CancellationToken cancellationToken)
    {
        var result = await emailHistoryService.Get(
            request.EmailHistoryFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<EmailHistoryDto>>(result);
    }
}
