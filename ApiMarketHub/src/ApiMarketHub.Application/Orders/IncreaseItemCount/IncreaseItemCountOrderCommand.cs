using Shared.Application;
using System;

namespace ApiMarketHub.Application.Orders.IncreaseItemCount;
public record IncreaseItemCountOrderCommand(long userId, long itemId, int count) : IBaseCommand;