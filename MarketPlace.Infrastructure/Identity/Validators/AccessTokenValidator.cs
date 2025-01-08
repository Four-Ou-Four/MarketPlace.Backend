using MarketPlace.Application.Common.Settings;
using MarketPlace.Domain.Entities;
using MarketPlace.Domain.Enums;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace MarketPlace.Infrastructure.Identity.Validators;

public class AccessTokenValidator : AbstractValidator<AccessToken>
{
    public AccessTokenValidator(IOptions<JwtSettings> jwtSettings)
    {
        var jwtSettingsValue = jwtSettings.Value;

        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(accessToken => accessToken.IsRevoked).NotEqual(true);

                RuleFor(accessToken => accessToken.UserId).NotEqual(Guid.Empty);
            }
        );

        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(accessToken => accessToken.Token).NotEmpty();

                RuleFor(accessToken => accessToken.ExpiryTime)
                    .GreaterThan(DateTimeOffset.UtcNow)
                    .Custom(
                        (accessToken, context) =>
                        {
                            if (accessToken > DateTimeOffset.UtcNow.AddMinutes(jwtSettingsValue.ExpirationTimeInMinutes))
                                context.AddFailure(
                                    nameof(AccessToken.ExpiryTime),
                                    $"{nameof(AccessToken.ExpiryTime)} cannot be greater than the expiration time of the JWT token."
                                );
                        }
                    );

                RuleFor(accessToken => accessToken)
                    .Custom(
                        (accessToken, context) =>
                        {
                            if (context.RootContextData.TryGetValue(nameof(AccessToken), out var userInfoObj) &&
                                userInfoObj is AccessToken foundAccessToken)
                                if (accessToken.UserId != foundAccessToken.UserId)
                                    context.AddFailure(nameof(AccessToken.UserId), $"{nameof(AccessToken.UserId)} cannot be changed.");
                        }
                    );

                RuleFor(accessToken => accessToken.IsRevoked).NotEqual(true);
            }
        );
    }
}