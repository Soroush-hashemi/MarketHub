using FluentValidation;
using Shared.Application.Validation;

namespace ApiMarketHub.Application.Roles.Create;
public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(r => r.Title).NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
    }
}