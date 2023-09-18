using FluentValidation;
using System.Threading.Tasks;

namespace ApiMarketHub.Application.Orders.DecreaseItemCount;
public class DecreaseItemCountOrderCommandValidator : AbstractValidator<DecreaseItemCountOrderCommand>
{
    public DecreaseItemCountOrderCommandValidator()
    {
        RuleFor(v => v.count).GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}