using Shared.Application;

namespace ApiMarketHub.Application.Sellers.ChangeStatus;
public record ChangeStatusSellerToAcceptedCommand(long SellerId) : IBaseCommand;