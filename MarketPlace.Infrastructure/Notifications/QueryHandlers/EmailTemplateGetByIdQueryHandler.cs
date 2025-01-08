using AutoMapper;
using MarketPlace.Application.Notifications.Models;
using MarketPlace.Application.Notifications.Queries;
using MarketPlace.Application.Notifications.Services;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Infrastructure.Notifications.Services;

namespace MarketPlace.Infrastructure.Notifications.QueryHandlers;

public class EmailTemplateGetByIdQueryHandler(
    IMapper mapper,
    IEmailTemplateService emailTemplateService)
    : IQueryHandler<EmailTemplateGetByIdQuery, EmailTemplateDto>
{
    public async Task<EmailTemplateDto> Handle(EmailTemplateGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await emailTemplateService.GetByIdAsync(request.EmailTemplateId, cancellationToken: cancellationToken);

        return mapper.Map<EmailTemplateDto>(result);
    }
}

