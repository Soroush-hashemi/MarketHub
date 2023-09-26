using FluentValidation;
using Shared.Application.Validation;
using Shared.Application.Validation.FluentValidations;

namespace ApiMarketHub.Application.Users.Edit;
public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator()
    {
        RuleFor(f => f.Avatar).JustImageFile();

        RuleFor(r => r.Email).EmailAddress().WithMessage("ایمیل نامعتبر است");

        RuleFor(v => v.Name).NotNull().NotEmpty().WithMessage(ValidationMessages.required("اسم"));

        RuleFor(v => v.Family).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));
    }
}