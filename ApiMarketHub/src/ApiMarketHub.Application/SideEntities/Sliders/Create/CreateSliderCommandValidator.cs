using FluentValidation;
using Shared.Application.Validation;
using Shared.Application.Validation.FluentValidations;

namespace ApiMarketHub.Application.SideEntities.Sliders.Create;
public class CreateSliderCommandValidator : AbstractValidator<CreateSliderCommand>
{
    public CreateSliderCommandValidator()
    {
        RuleFor(r => r.ImageFile).NotNull().WithMessage(ValidationMessages.required("عکس")).JustImageFile();
        RuleFor(r => r.Link).NotNull().NotEmpty().WithMessage(ValidationMessages.required("لینک"));
        RuleFor(r => r.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("لینک"));
    }
}