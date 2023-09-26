using ApiMarketHub.Domain.UserAggregate.Enums;
using Shared.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMarketHub.Application.Users.ChargeWallet;
public class ChargeWalletUserCommand : IBaseCommand
{
    public long UserId { get; private set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public bool IsFinally { get; private set; }
    public WalletType Type { get; private set; }
}