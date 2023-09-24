using FluentValidation;
using Shared.Application;
using Shared.Application.Validation;

namespace ApiMarketHub.Application.Sellers.Create;
public class CreateSellerCommandValidator : AbstractValidator<CreateSellerCommand>
{
    public CreateSellerCommandValidator()
    {
        RuleFor(v => v.ShopName).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));
        RuleFor(v => v.NationalCode).NotNull().NotEmpty().WithMessage(ValidationMessages.required("کدملی"));
    }
}