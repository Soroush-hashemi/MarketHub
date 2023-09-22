using FluentValidation;
using Shared.Application.Validation;
using Shared.Application.Validation.FluentValidations;

namespace ApiMarketHub.Application.SideEntities.Posters.Edit;
public class EditPosterCommandValidator : AbstractValidator<EditPosterCommand>
{
    public EditPosterCommandValidator()
    {
        RuleFor(r => r.ImageFile).NotNull().WithMessage(ValidationMessages.required("عکس")).JustImageFile();
        RuleFor(r => r.Link).NotNull().NotEmpty().WithMessage(ValidationMessages.required("لینک"));
    }
}