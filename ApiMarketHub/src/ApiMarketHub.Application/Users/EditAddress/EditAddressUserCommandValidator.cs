using FluentValidation;
using Shared.Application.Validation;
using Shared.Application.Validation.FluentValidations;

namespace ApiMarketHub.Application.Users.EditAddress;
public class EditAddressUserCommandValidator : AbstractValidator<EditAddressUserCommand>
{
    public EditAddressUserCommandValidator()
    {
        RuleFor(f => f.City).NotEmpty().WithMessage(ValidationMessages.required("شهر"));

        RuleFor(f => f.State).NotEmpty().WithMessage(ValidationMessages.required("استان"));

        RuleFor(f => f.Name).NotEmpty().WithMessage(ValidationMessages.required("نام"));

        RuleFor(f => f.Family).NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));

        RuleFor(f => f.NationalCode).NotEmpty().WithMessage(ValidationMessages.required("کدملی")).ValidNationalId();

        RuleFor(f => f.AddressDetail).NotEmpty().WithMessage(ValidationMessages.required("آدرس پستی"));

        RuleFor(f => f.PostalCode).NotEmpty().WithMessage(ValidationMessages.required("کد پستی"));
    }
}