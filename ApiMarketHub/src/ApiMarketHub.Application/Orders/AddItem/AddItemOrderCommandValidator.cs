using FluentValidation;

namespace ApiMarketHub.Application.Orders.AddItem;
public class AddItemOrderCommandValidator : AbstractValidator<AddItemOrderCommand>
{
    public AddItemOrderCommandValidator()
    {
        RuleFor(v => v.count).GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}