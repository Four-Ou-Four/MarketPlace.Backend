using MarketPlace.Domain.Entities;
using FluentValidation;

namespace MarketPlace.Infrastructure.Orders.Validators;
public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(order => order.UserId).NotEqual(Guid.Empty);
    }
}
