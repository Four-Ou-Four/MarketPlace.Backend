using AutoMapper;
using MarketPlace.Application.Notifications.Models;
using MarketPlace.Application.Notifications.Queries;
using MarketPlace.Application.Notifications.Services;
using MarketPlace.Domain.Common.Queries;

namespace MarketPlace.Infrastructure.Notifications.QueryHandlers;

public class EmailHistoryGetByIdQueryHandler(
    IMapper mapper,
    IEmailHistoryService emailHistoryService)
    : IQueryHandler<EmailHistoryGetByIdQuery, EmailHistoryDto>
{
    public async Task<EmailHistoryDto> Handle(EmailHistoryGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await emailHistoryService.GetByIdAsync(request.EmailHistoryId, cancellationToken: cancellationToken);

        return mapper.Map<EmailHistoryDto>(result);
    }
}
