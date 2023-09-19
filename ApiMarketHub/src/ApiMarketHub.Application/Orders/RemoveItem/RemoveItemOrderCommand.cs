using Shared.Application;

namespace ApiMarketHub.Application.Orders.RemoveItem;
public record RemoveItemOrderCommand(long userId,long ItemId) : IBaseCommand;