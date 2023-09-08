using Shared.Domain.Bases;

namespace ApiMarketHub.Domain.OrderAggregate.Events;

public class OrderFinalized : BaseDomainEvent
{
    public OrderFinalized(long orderId)
    {
        OrderId = orderId;
    }

    public long OrderId { get; private set; }
}