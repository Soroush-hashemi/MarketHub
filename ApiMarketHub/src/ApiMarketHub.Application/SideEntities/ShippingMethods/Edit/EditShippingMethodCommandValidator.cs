using FluentValidation;
using Shared.Application.Validation;

namespace ApiMarketHub.Application.SideEntities.ShippingMethods.Edit;
public class EditShippingMethodCommandValidator : AbstractValidator<EditShippingMethodCommand>
{
    public EditShippingMethodCommandValidator()
    {
        RuleFor(v => v.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
    }
}