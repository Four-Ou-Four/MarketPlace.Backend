using MarketPlace.Application.Notifications.Models;

namespace MarketPlace.Application.Notifications.Services;

public interface IEmailRenderingService
{
    ValueTask<string> RenderAsync(
        EmailMessage emailMessage,
        CancellationToken cancellationToken = default
    );
}