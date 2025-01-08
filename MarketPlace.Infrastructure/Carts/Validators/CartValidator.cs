using MarketPlace.Domain.Entities;
using FluentValidation;

namespace MarketPlace.Infrastructure.Carts.Validators;
public class CartValidator : AbstractValidator<Cart>
{
    public CartValidator()
    {
        RuleFor(cart => cart.UserId).NotEqual(Guid.Empty);
    }
}
