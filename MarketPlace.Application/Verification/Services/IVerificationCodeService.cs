using MarketPlace.Domain.Enums;

namespace MarketPlace.Application.Verification.Services;

public interface IVerificationCodeService
{
    ValueTask<VerificationType?> GetVerificationTypeAsync(string code, CancellationToken cancellationToken = default);
}
