using AutoMapper;
using MarketPlace.Application.Identity.Models;
using MarketPlace.Application.Identity.Services;
using MarketPlace.Domain.Common.Queries;
using MarketPlace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Security.Authentication;

namespace MarketPlace.Infrastructure.Identity.Services;

public class AuthAggregationService(
    IMapper mapper,
    IPasswordGeneratorService passwordGeneratorService,
    IPasswordHasherService passwordHasherService,
    IAccountAggregatorService accountAggregatorService,
    IUserService userService,
    IAccessTokenGeneratorService accessTokenGeneratorService,
    IAccessTokenService accessTokenService
) : IAuthAggregationService
{
    public async ValueTask<bool> SignUpAsync(SignUpDetails signUpDetails, CancellationToken cancellationToken = default)
    {
        var foundUserId = await userService.GetIdByEmailAddressAsync(signUpDetails.EmailAddress, cancellationToken);

        if (foundUserId.HasValue)
            throw new InvalidOperationException("User already exists");

        // Hash password
        var user = mapper.Map<User>(signUpDetails);
        var password = signUpDetails.AutoGeneratePassword
            ? passwordGeneratorService.GeneratePassword()
            : passwordGeneratorService.GetValidatedPassword(signUpDetails.Password!, user);

        user.PasswordHash = passwordHasherService.HashPassword(password);

        // Create user
        return await accountAggregatorService.CreateUserAsync(user, cancellationToken);
    }

    public async ValueTask<string> SignInAsync(SignInDetails signInDetails, CancellationToken cancellationToken = default)
    {
        var foundUser =
            await userService.Get(user => user.EmailAddress == signInDetails.EmailAddress,
                queryOptions: new QueryOptions(QueryTrackingMode.AsNoTracking))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (foundUser is null || !passwordHasherService.ValidatePassword(signInDetails.Password, foundUser.PasswordHash))
            throw new AuthenticationException("Sign in details are invalid, contact support.");

        var accessToken = accessTokenGeneratorService.GetToken(foundUser);

        await accessTokenService.CreateAsync(accessToken, cancellationToken: cancellationToken);

        return new(accessToken.Token);
    }
}