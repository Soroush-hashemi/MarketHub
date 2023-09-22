using FluentValidation;
using Shared.Application.Validation;
using Shared.Application.Validation.FluentValidations;

namespace ApiMarketHub.Application.SideEntities.Posters.Create;
public class CreatePosterCommandValidator : AbstractValidator<CreatePosterCommand>
{
    public CreatePosterCommandValidator()
    {
        RuleFor(r => r.ImageFile).NotNull().WithMessage(ValidationMessages.required("عکس")).JustImageFile();

        RuleFor(r => r.Link).NotNull().NotEmpty().WithMessage(ValidationMessages.required("لینک"));
    }
}