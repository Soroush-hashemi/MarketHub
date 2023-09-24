using ApiMarketHub.Domain.SellerAggregate.Enum;
using Shared.Application;

namespace ApiMarketHub.Application.Sellers.Edit;
public class EditSellerCommand : IBaseCommand
{
    public long SellerId { get; set; }
    public long UserId { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatus Status { get; set; }
}