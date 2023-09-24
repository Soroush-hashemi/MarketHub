using FluentValidation;
using Shared.Application.Validation;

namespace ApiMarketHub.Application.Sellers.Edit;
public class EditSellerCommandValidator : AbstractValidator<EditSellerCommand>
{
    public EditSellerCommandValidator()
    {
        RuleFor(v => v.ShopName).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));
        RuleFor(v => v.NationalCode).NotNull().NotEmpty().WithMessage(ValidationMessages.required("کدملی"));
    }
}