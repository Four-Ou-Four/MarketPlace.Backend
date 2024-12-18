using MarketPlace.Domain.Entities;

namespace MarketPlace.Application.Identity.Services;

public interface IPasswordGeneratorService
{
    string GeneratePassword();

    string GetValidatedPassword(string password, User user);
}