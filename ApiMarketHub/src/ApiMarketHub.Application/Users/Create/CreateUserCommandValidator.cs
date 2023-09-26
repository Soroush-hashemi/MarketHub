using FluentValidation;
using Shared.Application.Validation;
using Shared.Application.Validation.FluentValidations;

namespace ApiMarketHub.Application.Users.Create;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(r => r.Email).EmailAddress().WithMessage("ایمیل نامعتبر است");

        RuleFor(v => v.Name).NotNull().NotEmpty().WithMessage(ValidationMessages.required("اسم"));

        RuleFor(v => v.Family).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));

        RuleFor(f => f.Password).NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
            .NotNull().WithMessage(ValidationMessages.required("کلمه عبور"))
            .MinimumLength(4).WithMessage("کلمه عبور باید بشتر از 4 کارکتر باشد");
    }
}