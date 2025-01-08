using AutoMapper;
using MarketPlace.Application.Identity.Commands;
using MarketPlace.Application.Identity.Models;
using MarketPlace.Application.Identity.Services;
using MarketPlace.Application.Notifications.Commands;
using MarketPlace.Application.Notifications.Models;
using MarketPlace.Application.Notifications.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Entities;

namespace MarketPlace.Infrastructure.Notifications.CommandHandlers;

public class EmailTemplateCreateCommandHandler(
    IMapper mapper,
    IEmailTemplateService emailTemplateService) : ICommandHandler<EmailTemplateCreateCommand, EmailTemplateDto>
{
    public async Task<EmailTemplateDto> Handle(EmailTemplateCreateCommand request, CancellationToken cancellationToken)
    {
        var emailTemplate = mapper.Map<EmailTemplate>(request.EmailTemplateDto);

        var createdEmailTemplate = await emailTemplateService.CreateAsync(emailTemplate, cancellationToken: cancellationToken);

        return mapper.Map<EmailTemplateDto>(createdEmailTemplate);
    }
}
