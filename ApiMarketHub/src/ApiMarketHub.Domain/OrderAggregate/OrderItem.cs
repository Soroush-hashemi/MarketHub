using Shared.Domain.Bases;
using Shared.Domain.Exceptions;

namespace ApiMarketHub.Domain.OrderAggregate;
public class OrderItem : BaseEntity
{
    public long OrderId { get; internal set; }
    public long InventoryId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }
    public int TotalPrice => Price * Count;
    public OrderItem(long inventoryId, int count, int price)
    {
        PriceGuard(price);
        CountGuard(count);

        InventoryId = inventoryId;
        Count = count;
        Price = price;
    }

    public void IncreaseCount(int count)
    {
        Count += count;
    }

    public void DecreaseCount(int count)
    {
        if (Count == 0)
            return;
        if (Count == 1)
            return;
        Count -= count;
    }

    public void ChangeCount(int count)
    {
        CountGuard(count);
        Count = count;
    }

    public void SetPrice(int newPrice)
    {
        PriceGuard(newPrice);
        Price = newPrice;
    }

    public void PriceGuard(int NewPrice)
    {
        if (NewPrice < 1)
            throw new InvalidDomainDataException("price is invalid");
    }

    public void CountGuard(int count)
    {
        if (count < 1)
            throw new InvalidDomainDataException();
    }
}