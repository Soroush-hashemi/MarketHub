using ApiMarketHub.Domain.OrderAggregate.Enum;
using Shared.Query.Bases;

namespace ApiMarketHub.Query.Orders.DTOs;
public class OrderFilterDataDto : BaseDto
{
    public long UserId { get; set; }
    public string UserFullName { get; set; }
    public OrderStatus Status { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
    public string? ShippingType { get; set; }
    public int TotalPrice { get; set; }
    public int TotalItemCount { get; set; }
}