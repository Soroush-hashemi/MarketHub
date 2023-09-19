using Shared.Application;

namespace ApiMarketHub.Application.Orders.AddItem;
public record AddItemOrderCommand(long inventoryId, int count, int userId) : IBaseCommand;