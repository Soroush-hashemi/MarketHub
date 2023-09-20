using FluentValidation;
using Shared.Application.Validation;

namespace ApiMarketHub.Application.Roles.Edit;
public class EditRoleCommandValidator : AbstractValidator<EditRoleCommand>
{
    public EditRoleCommandValidator()
    {
        RuleFor(r => r.Title).NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
    }
}