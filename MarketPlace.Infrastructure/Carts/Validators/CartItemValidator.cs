using MarketPlace.Domain.Entities;
using MarketPlace.Domain.Enums;
using FluentValidation;

namespace MarketPlace.Infrastructure.Carts.Validators;
public class CartItemValidator : AbstractValidator<CartItem>
{
    public CartItemValidator()
    {
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(cartItem => cartItem.CartId).NotEqual(Guid.Empty);
                RuleFor(cartItem => cartItem.ProductId).NotEqual(Guid.Empty);
                RuleFor(cartItem => cartItem.Quantity).NotEmpty().GreaterThanOrEqualTo(1);
            });

        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(cartItem => cartItem.ProductId).NotEqual(Guid.Empty);
                RuleFor(cartItem => cartItem.Quantity).NotEmpty().GreaterThanOrEqualTo(1);
            });
    }
}
