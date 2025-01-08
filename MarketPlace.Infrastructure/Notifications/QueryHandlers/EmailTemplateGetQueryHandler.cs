using AutoMapper;
using MarketPlace.Application.Notifications.Models;
using MarketPlace.Application.Notifications.Queries;
using MarketPlace.Application.Notifications.Services;
using MarketPlace.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Notifications.QueryHandlers;

public class EmailTemplateGetQueryHandler(
    IMapper mapper,
    IEmailTemplateService emailTemplateService)
    : IQueryHandler<EmailTemplateGetQuery, ICollection<EmailTemplateDto>>
{
    public async Task<ICollection<EmailTemplateDto>> Handle(EmailTemplateGetQuery request, CancellationToken cancellationToken)
    {
        var result = await emailTemplateService.Get(
            request.EmailTemplateFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<EmailTemplateDto>>(result);
    }
}
