using MarketPlace.Domain.Entities;
using FluentValidation;

namespace MarketPlace.Infrastructure.Categories.Validators;
public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(category => category.Name).NotEmpty().MinimumLength(2);
    }
}
