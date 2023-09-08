using Shared.Domain.Bases;

namespace ApiMarketHub.Domain.OrderAggregate.ValueObjects;
public class OrderDiscount : BaseValueObject
{
    public OrderDiscount(string discountTitle, int discountAmount)
    {
        DiscountTitle = discountTitle;
        DiscountAmount = discountAmount;
    }

    public string DiscountTitle { get; private set; }
    public int DiscountAmount { get; private set; }
}