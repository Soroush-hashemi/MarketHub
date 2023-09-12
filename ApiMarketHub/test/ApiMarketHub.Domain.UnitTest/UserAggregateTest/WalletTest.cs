using ApiMarketHub.Domain.UnitTest.UserAggregateTest.Builder;
using FluentAssertions;
using Shared.Domain.Exceptions;
using Xunit;

namespace ApiMarketHub.Domain.UnitTest.UserAggregateTest;
public class WalletTest
{
    private readonly WalletBuilder _walletBuilder;
    public WalletTest()
    {
        _walletBuilder = new WalletBuilder();
    }

    [Fact]
    public void Constructor_Should_Throw_InvalidDomainDataException_When_Price_IsUnder_Thousand()
    {
        // Arrange & Act
        Action act = () => _walletBuilder.CreateWalletWithWrongPrice();

        // Assert
        act.Should().Throw<InvalidDomainDataException>();
    }

    [Fact]
    public void Constructor_Should_Create_New_Wallet_With_WalletDeposit()
    {
        // Arrange & Act
        var wallet = _walletBuilder.CreateWallet();

        // Assert
        _walletBuilder.AssertForCreateWallet(wallet);
    }

    [Fact]
    public void Constructor_Should_Create_New_Wallet_With_WalletWithdrawal()
    {
        // Arrange & Act
        var wallet = _walletBuilder.CreateWallet();

        // Assert
        _walletBuilder.AssertForCreateWallet(wallet);
    }

    [Fact]
    public void Finally_With_RefCode()
    {
        // Arrange
        var wallet = _walletBuilder.CreateWallet();

        // Act
        wallet.Finally("321456");

        // Assert
        wallet.IsFinally.Should().BeTrue();
        wallet.Description.Should().Be("Test Description'\n کد پیگیری : 321456");

    }
}