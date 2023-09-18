using FluentValidation;
using Shared.Application.Validation;
using Shared.Application.Validation.FluentValidations;

namespace ApiMarketHub.Application.Orders.Checkout;
public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandValidator()
    {
        RuleFor(v => v.City)
           .NotNull().NotEmpty()
           .WithMessage(ValidationMessages.required("شهر"));

        RuleFor(v => v.State)
           .NotNull().NotEmpty()
           .WithMessage(ValidationMessages.required("استان"));

        RuleFor(v => v.Name)
           .NotNull().NotEmpty()
           .WithMessage(ValidationMessages.required("اسم"));

        RuleFor(v => v.Family)
           .NotEmpty().NotNull()
           .WithMessage(ValidationMessages.required("نام خانوادگی"));

        RuleFor(v => v.AddressDetail)
          .NotNull().NotEmpty()
          .WithMessage(ValidationMessages.required("جزئیات آدرس"));

        RuleFor(v => v.PostalCode)
          .NotNull().NotEmpty()
          .WithMessage(ValidationMessages.required("کد پستی"));

        RuleFor(v => v.PhoneNumber)
          .NotNull()
          .NotEmpty()
          .WithMessage(ValidationMessages.required("شماره"))
          .MaximumLength(11).WithMessage("شماره موبایل نامعتبر است")
          .MinimumLength(11).WithMessage("شماره موبایل نامعتبر است");

        RuleFor(v => v.NationalCode)
         .NotNull()
         .NotEmpty()
         .WithMessage(ValidationMessages.required("کد ملی"))
         .MaximumLength(10).WithMessage(" کدملی نامعتبر است")
         .MinimumLength(10).WithMessage("کدملی نامعتبر است")
         .ValidNationalId();
    }
}