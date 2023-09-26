using ApiMarketHub.Domain.UserAggregate.Enums;
using Shared.Application;

namespace ApiMarketHub.Application.Users.ChargeWallet;
public class ChargeWalletUserCommand : IBaseCommand
{
    public long UserId { get; private set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public WalletType Type { get; private set; }

    public ChargeWalletUserCommand(long userId, int price, string description, bool isFinally, WalletType type)
    {
        UserId = userId;
        Price = price;
        Description = description;
        IsFinally = isFinally;
        Type = type;
    }
}