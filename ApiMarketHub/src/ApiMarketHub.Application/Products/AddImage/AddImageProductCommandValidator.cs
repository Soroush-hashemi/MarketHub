using FluentValidation;
using Shared.Application.Validation;
using Shared.Application.Validation.FluentValidations;

namespace ApiMarketHub.Application.Products.AddImage;
public class AddImageProductCommandValidator : AbstractValidator<AddImageProductCommand>
{
    public AddImageProductCommandValidator()
    {
        RuleFor(b => b.ImageFile).NotNull().WithMessage(ValidationMessages.required("عکس")).JustImageFile();
        RuleFor(b => b.Sequence).GreaterThanOrEqualTo(0);
    }
}