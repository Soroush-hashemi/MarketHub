using FluentValidation;
using Shared.Application.Validation;

namespace ApiMarketHub.Application.SideEntities.ShippingMethods.Create;
public class CreateShippingMethodCommandValidator : AbstractValidator<CreateShippingMethodCommand>
{
    public CreateShippingMethodCommandValidator()
    {
        RuleFor(v => v.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
    }
}