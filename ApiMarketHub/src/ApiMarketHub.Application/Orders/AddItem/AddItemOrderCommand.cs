using Shared.Application;
using System;

namespace ApiMarketHub.Application.Orders.AddItem;
public record AddItemOrderCommand(long inventoryId, int count, int userId) : IBaseCommand;