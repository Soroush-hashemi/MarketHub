using FluentValidation;
using Shared.Application.Validation;

namespace ApiMarketHub.Application.Categories.AddChild;
public class AddChildCategoryCommandValidator : AbstractValidator<AddChildCategoryCommand>
{
    public AddChildCategoryCommandValidator()
    {
        RuleFor(v => v.title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Title"));
        RuleFor(v => v.slug).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
    }
}