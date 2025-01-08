using MarketPlace.Application.Identity.Services;
using MarketPlace.Domain.Common.Commands;
using MarketPlace.Domain.Entities;
using MarketPlace.Domain.Enums;
using MarketPlace.Persistence.Repositories.Interfaces;
using FluentValidation;
using MarketPlace.Infrastructure.Identity.Validators;


namespace MarketPlace.Infrastructure.Identity.Services;

public class AccessTokenService(
    IAccessTokenRepository accessTokenRepository,
    AccessTokenValidator accessTokenValidator)
   : IAccessTokenService
{
    public async ValueTask<AccessToken> CreateAsync(
        AccessToken accessToken,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await accessTokenValidator.ValidateAsync(
            accessToken,
            options => options
            .IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await accessTokenRepository.CreateAsync(accessToken, commandOptions, cancellationToken);
    }

    public ValueTask<AccessToken?> GetByIdAsync(
        Guid accessTokenId,
        CancellationToken cancellationToken = default) =>
    accessTokenRepository.GetByIdAsync(accessTokenId, cancellationToken);

    public async ValueTask RevokeAsync(
        Guid accessTokenId,
        CancellationToken cancellationToken = default)
    {
        var accessToken = await GetByIdAsync(accessTokenId, cancellationToken);
        if (accessToken is null) throw new InvalidOperationException($"Access token with id {accessTokenId} not found.");

        accessToken.IsRevoked = true;
        await accessTokenRepository.UpdateAsync(accessToken, cancellationToken);
    }
}
