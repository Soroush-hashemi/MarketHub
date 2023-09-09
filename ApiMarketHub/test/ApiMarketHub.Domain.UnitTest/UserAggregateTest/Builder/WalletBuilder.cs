using ApiMarketHub.Domain.UserAggregate.Enums;
using ApiMarketHub.Domain.UserAggregate;
using FluentAssertions;

namespace ApiMarketHub.Domain.UnitTest.UserAggregateTest.Builder;
public class WalletBuilder
{
    public Wallet CreateWalletWithWrongPrice()
    {
        int price = 0;
        string description = "";
        bool isFinally = false;

        var wallet = new Wallet(price, description, isFinally, WalletType.Withdrawal);
        return wallet;
    }

    public Wallet CreateWalletDeposit()
    {
        int price = 20000;
        string description = "Test Description";
        bool isFinally = false;

        var wallet = new Wallet(price, description, isFinally, WalletType.Deposit);
        return wallet;
    }

    public Wallet CreateWalletWithdrawal()
    {
        int price = 20000;
        string description = "Test Description";
        bool isFinally = false;

        var wallet = new Wallet(price, description, isFinally, WalletType.Withdrawal);
        return wallet;
    }

    public void AssertForCreateWalletDeposit(Wallet wallet)
    {
        wallet.Price.Should().Be(20000);
        wallet.Description.Should().Be("Test Description");
        wallet.IsFinally.Should().Be(false);
        wallet.Type.Should().Be(WalletType.Deposit);
    }

    public void AssertForCreateWalletWithdrawal(Wallet wallet)
    {
        wallet.Price.Should().Be(20000);
        wallet.Description.Should().Be("Test Description");
        wallet.IsFinally.Should().Be(false);
        wallet.Type.Should().Be(WalletType.Withdrawal);
    }
}