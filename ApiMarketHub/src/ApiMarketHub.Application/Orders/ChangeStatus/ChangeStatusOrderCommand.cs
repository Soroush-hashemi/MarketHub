using Shared.Application;
using ApiMarketHub.Domain.OrderAggregate.Enum;

namespace ApiMarketHub.Application.Orders.ChangeStatus;
public record ChangeStatusOrderCommand(long orderId, OrderStatus changeStatus) : IBaseCommand;