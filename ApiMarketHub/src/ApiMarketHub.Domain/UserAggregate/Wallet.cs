using ApiMarketHub.Domain.UserAggregate.Enums;
using Shared.Domain.Bases;
using Shared.Domain.Exceptions;

namespace ApiMarketHub.Domain.UserAggregate;
public class Wallet : BaseEntity
{
    public long UserId { get; internal set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public DateTime? FinallyDate { get; private set; }
    public WalletType Type { get; private set; }

    public Wallet(int price, string description, bool isFinally, WalletType type)
    {
        if (price < 1000)
            throw new InvalidDomainDataException();
        Price = price;
        Description = description;
        IsFinally = isFinally;
        Type = type;
        if (isFinally)
            FinallyDate = DateTime.Now;
    }

    public void Finally(string refCode) // کد پیگیری
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
        Description += $"'\n کد پیگیری : {refCode}";
    }

    public void Finally()
    {
        IsFinally = true;
        FinallyDate = DateTime.Now;
    }
}