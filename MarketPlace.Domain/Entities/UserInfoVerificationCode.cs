using MarketPlace.Domain.Enums;

namespace MarketPlace.Domain.Entities;

public class UserInfoVerificationCode : VerificationCode
{
    public UserInfoVerificationCode()
    {
        Type = VerificationType.UserInfoVerificationCode;
    }

    public Guid UserId { get; set; }
}