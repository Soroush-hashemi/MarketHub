using Shared.Application;
namespace ApiMarketHub.Application.Orders.DecreaseItemCount;
public record DecreaseItemCountOrderCommand(long userId, long itemId, int count) : IBaseCommand;