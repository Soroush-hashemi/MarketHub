using FluentValidation;
using Shared.Application.Validation;

namespace ApiMarketHub.Application.Users.ChargeWallet;
public class ChargeWalletUserCommandValidator : AbstractValidator<ChargeWalletUserCommand>
{
    public ChargeWalletUserCommandValidator()
    {
        RuleFor(r => r.Description).NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

        RuleFor(r => r.Price).GreaterThanOrEqualTo(1000);
    }
}