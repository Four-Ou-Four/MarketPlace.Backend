using MarketPlace.Domain.Entities;
using MarketPlace.Domain.Enums;
using FluentValidation;

namespace MarketPlace.Infrastructure.Orders.Validators;
public class OrderItemValidator : AbstractValidator<OrderItem>
{
    public OrderItemValidator()
    {
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(orderItem => orderItem.OrderId).NotEqual(Guid.Empty);
                RuleFor(orderItem => orderItem.ProductId).NotEqual(Guid.Empty);
                RuleFor(orderItem => orderItem.Quantity).GreaterThan(0);
                RuleFor(orderItem => orderItem.TotalPrice).GreaterThan(0);
            });

        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(orderItem => orderItem.ProductId).NotEqual(Guid.Empty);
                RuleFor(orderItem => orderItem.Quantity).GreaterThan(0);
            });
    }
}
