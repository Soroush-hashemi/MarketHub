using Shared.Application;

namespace ApiMarketHub.Application.Sellers.ChangeStatus;
public record ChangeStatusSellerToRejectedCommand(long SellerId) : IBaseCommand;