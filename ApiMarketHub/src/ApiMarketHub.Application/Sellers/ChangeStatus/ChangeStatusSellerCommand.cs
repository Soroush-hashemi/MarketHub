using ApiMarketHub.Domain.SellerAggregate.Enum;
using Shared.Application;

namespace ApiMarketHub.Application.Sellers.ChangeStatus;
public record ChangeStatusSellerCommand(long SellerId, SellerStatus Status) : IBaseCommand;