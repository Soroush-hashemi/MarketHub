using FluentValidation;
using Shared.Application;
using Shared.Application.Validation;

namespace ApiMarketHub.Application.Products.Edit;
public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
{
    public EditProductCommandValidator()
    {
        RuleFor(r => r.Title).NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

        RuleFor(r => r.Slug).NotEmpty().WithMessage(ValidationMessages.required("Slug"));

        RuleFor(r => r.Description).NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

        RuleFor(r => r.ImageName).JustImageFile();

    }
}