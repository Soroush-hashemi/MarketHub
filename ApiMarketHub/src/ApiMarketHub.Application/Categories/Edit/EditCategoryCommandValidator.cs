using FluentValidation;
using Shared.Application.Validation;

namespace ApiMarketHub.Application.Categories.Edit;
public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
{
    public EditCategoryCommandValidator()
    {
        RuleFor(v => v.title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Title"));
        RuleFor(v => v.slug).NotNull().NotEmpty().WithMessage(ValidationMessages.required("Slug"));
    }
}