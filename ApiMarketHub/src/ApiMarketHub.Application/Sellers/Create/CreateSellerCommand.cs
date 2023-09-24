using ApiMarketHub.Domain.SellerAggregate.Enum;
using Shared.Application;

namespace ApiMarketHub.Application.Sellers.Create;
public class CreateSellerCommand : IBaseCommand
{
    public CreateSellerCommand(long userId, string shopName, string nationalCode)
    {
        UserId = userId;
        ShopName = shopName;
        NationalCode = nationalCode;
    }

    public long UserId { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
}