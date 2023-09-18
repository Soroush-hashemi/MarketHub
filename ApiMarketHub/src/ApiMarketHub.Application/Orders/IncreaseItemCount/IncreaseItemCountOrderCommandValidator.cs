using FluentValidation;

namespace ApiMarketHub.Application.Orders.IncreaseItemCount;
public class IncreaseItemCountOrderCommandValidator : AbstractValidator<IncreaseItemCountOrderCommand>
{
    public IncreaseItemCountOrderCommandValidator()
    {
        RuleFor(v => v.count).GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}