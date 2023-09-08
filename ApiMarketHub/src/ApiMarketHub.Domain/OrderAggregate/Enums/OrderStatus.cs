using System;

namespace ApiMarketHub.Domain.OrderAggregate.Enums;
public enum OrderStatus 
{
    Pending,
    Finally,
    Shipping,
    Rejected
}