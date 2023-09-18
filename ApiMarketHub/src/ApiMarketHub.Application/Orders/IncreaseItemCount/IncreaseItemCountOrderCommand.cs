using Shared.Application;

namespace ApiMarketHub.Application.Orders.IncreaseItemCount;
public record IncreaseItemCountOrderCommand(long userId, long itemId, int count ) : IBaseCommand;