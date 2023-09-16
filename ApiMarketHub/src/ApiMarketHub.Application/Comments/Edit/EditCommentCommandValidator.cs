﻿using FluentValidation;
using Shared.Application.Validation;

namespace ApiMarketHub.Application.Comments.Edit;
public class EditCommentCommandValidator : AbstractValidator<EditCommentCommand>
{
    public EditCommentCommandValidator()
    {
        RuleFor(v => v.text).NotNull().WithMessage(ValidationMessages.Required);
        RuleFor(v => v.text).MinimumLength(10).WithMessage(ValidationMessages.minLength("text", 10));
        RuleFor(v => v.text).MaximumLength(500).WithMessage(ValidationMessages.maxLength("text", 500));
    }
}