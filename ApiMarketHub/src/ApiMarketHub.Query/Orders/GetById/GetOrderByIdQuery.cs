using ApiMarketHub.Query.Orders.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Orders.GetById;
public record GetOrderByIdQuery(long orderId) : IQuery<OrderDto?>;