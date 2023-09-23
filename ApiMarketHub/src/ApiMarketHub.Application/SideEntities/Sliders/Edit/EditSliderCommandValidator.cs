using FluentValidation;
using Shared.Application.Validation;
using Shared.Application.Validation.FluentValidations;

namespace ApiMarketHub.Application.SideEntities.Sliders.Edit;
public class EditSliderCommandValidator : AbstractValidator<EditSliderCommand>
{
    public EditSliderCommandValidator()
    {
        RuleFor(r => r.ImageFile).NotNull().WithMessage(ValidationMessages.required("عکس")).JustImageFile();
        RuleFor(r => r.Link).NotNull().NotEmpty().WithMessage(ValidationMessages.required("لینک"));
        RuleFor(r => r.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("لینک"));
    }
}