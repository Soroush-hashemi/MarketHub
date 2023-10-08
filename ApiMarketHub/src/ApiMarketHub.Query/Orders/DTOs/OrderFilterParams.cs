using ApiMarketHub.Domain.OrderAggregate.Enum;
using Shared.Query.Bases;

namespace ApiMarketHub.Query.Orders.DTOs;
public class OrderFilterParams : BaseFilterParam
{
    public long? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public OrderStatus? Status { get; set; }
}

public class OrderFilterResult : BaseFilter<OrderFilterDataDto, OrderFilterParams>
{
}