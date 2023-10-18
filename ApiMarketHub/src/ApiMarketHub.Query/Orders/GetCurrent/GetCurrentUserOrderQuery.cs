using ApiMarketHub.Query.Orders.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Orders.GetCurrent;
public record GetCurrentUserOrderQuery(long userId) : IQuery<OrderDto?>;