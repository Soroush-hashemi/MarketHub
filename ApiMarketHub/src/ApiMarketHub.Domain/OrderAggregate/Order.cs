using ApiMarketHub.Domain.OrderAggregate.Enum;
using ApiMarketHub.Domain.OrderAggregate.Events;
using ApiMarketHub.Domain.OrderAggregate.ValueObjects;
using Shared.Domain.Bases;
using Shared.Domain.Exceptions;

namespace ApiMarketHub.Domain.OrderAggregate;
public class Order : AggregateRoot
{
    public long UserId { get; private set; }
    public OrderStatus Status { get; private set; }
    public OrderDiscount? Discount { get; private set; }
    public OrderAddress? Address { get; private set; }
    public OrderShippingMethod? ShippingMethod { get; private set; }
    public List<OrderItem> Items { get; private set; }
    public DateTime? LastUpdate { get; set; }
    public int ItemCount => Items.Count;

    public int TotalPrice
    {
        get
        {
            var totalPrice = Items.Sum(f => f.TotalPrice);
            if (ShippingMethod != null)
                totalPrice += ShippingMethod.ShippingCost;

            if (Discount != null)
                totalPrice -= Discount.DiscountAmount;

            return totalPrice;
        }
    }

    private Order()
    {

    }

    public Order(long userId)
    {
        UserId = userId;
        Status = OrderStatus.Pending;
        Items = new List<OrderItem>();
    }


    public void AddItem(OrderItem item)
    {
        ChangeOrderGuard();
        var previousItem = Items.FirstOrDefault(i => i.InventoryId == item.InventoryId);

        if (previousItem != null)
        {
            previousItem.ChangeCount(item.Count + previousItem.Count);
            return;
        }

        Items.Add(item);
    }

    public void RemoveItem(long itemId)
    {
        ChangeOrderGuard();
        var currentItem = Items.FirstOrDefault(i => i.Id == itemId);
        if (currentItem != null)
            Items.Remove(currentItem);
    }

    public void IncreaseItemCount(long itemId, int count)
    {
        ChangeOrderGuard();
        var currentItem = Items.FirstOrDefault(i => i.Id == itemId);
        if (currentItem == null)
            throw new NullOrEmptyException();
        currentItem.IncreaseCount(count);
    }

    public void DecreaseItemCount(long itemId, int count)
    {
        ChangeOrderGuard();
        var currentItem = Items.FirstOrDefault(i => i.Id == itemId);
        if (currentItem == null)
            throw new NullOrEmptyException();
        currentItem.DecreaseCount(count);
    }

    public void ChangeCountItem(long itemId, int newCount)
    {
        ChangeOrderGuard();

        var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
        if (currentItem == null)
            throw new NullOrEmptyException();

        currentItem.ChangeCount(newCount);
    }

    public void Finally()
    {
        Status = OrderStatus.Finally;
        LastUpdate = DateTime.Now;
        AddDomainEvent(new OrderFinalized(Id));
    }

    public void ChangeStatus(OrderStatus status)
    {
        Status = status;
        LastUpdate = DateTime.Now;
    }

    public void Checkout(OrderAddress orderAddress, OrderShippingMethod shippingMethod)
    {
        ChangeOrderGuard();

        Address = orderAddress;
        ShippingMethod = shippingMethod;
    }

    // rename
    public void ChangeOrderGuard()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidDomainDataException();
    }
}