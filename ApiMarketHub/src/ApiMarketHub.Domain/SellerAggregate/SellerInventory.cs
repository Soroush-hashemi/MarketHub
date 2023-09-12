using Shared.Domain.Bases;
using Shared.Domain.Exceptions;

namespace ApiMarketHub.Domain.SellerAggregate;
public class SellerInventory : BaseEntity
{
    public long SellerId { get; internal set; }
    public long ProductId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int? DiscountPercentage { get; private set; }

    public SellerInventory(long productId, int count, int price, int? discountPercentage = null)
    {
        Guard(count, price);
        ProductId = productId;
        Count = count;
        Price = price;
        DiscountPercentage = discountPercentage;
    }

    public void Edit(int count, int price, int? discountPercentage = null)
    {
        Guard(count, price);
        Count = count;
        Price = price;
        DiscountPercentage = discountPercentage;
    }

    public void Guard(int count, int price)
    {
        if (price < 1 || count < 0)
            throw new InvalidDomainDataException();
    }
}