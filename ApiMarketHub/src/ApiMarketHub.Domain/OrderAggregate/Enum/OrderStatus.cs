using System;

namespace ApiMarketHub.Domain.OrderAggregate.Enum;
public enum OrderStatus 
{
    Pending,
    Finally,
    Shipping,
    Rejected
}