using Shared.Application;

namespace ApiMarketHub.Application.Orders.Finally;
public record FinallyOrderCommand(long orderId) : IBaseCommand;