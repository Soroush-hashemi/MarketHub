using ApiMarketHub.Domain.UnitTest.UserAggregateTest.Builder;
using ApiMarketHub.Domain.UserAggregate;
using ApiMarketHub.Domain.UserAggregate.Enums;
using ApiMarketHub.Domain.UserAggregate.Service;
using FluentAssertions;
using NSubstitute;
using Shared.Domain.Exceptions;
using Shared.Domain.ValueObjects;
using System.Xml.Linq;
using Xunit;

namespace ApiMarketHub.Domain.UnitTest.UserAggregateTest;
public class UserTest
{
    private readonly UserBuilder _userBuilder;
    private readonly UserAddressBuilder _userAddressBuilder;
    private readonly WalletBuilder _walletBuilder;
    public UserTest()
    {
        _userBuilder = new UserBuilder();
        _userAddressBuilder = new UserAddressBuilder();
        _walletBuilder = new WalletBuilder();
    }

    [Fact]
    public void Constructor_Should_Set_User()
    {
        // Arrange & Act
        var user = _userBuilder.Constructor_User();

        // Assert
        _userBuilder.AssertForConstructorFull_User(user);
    }

    [Fact]
    public void Edit_Should_Edit_User()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();
        var userDomainService = Substitute.For<IUserDomainService>();

        // Act
        user.Edit("soroush2", "hashemi2", new PhoneNumber("09902224455"),
            "soroush8@gmail.com", Gender.NONE, userDomainService);

        // Assert
        _userBuilder.AssertForEdit(user);
    }

    [Fact]
    public void ChangePassword_Should_ChangePassword()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();

        // Act
        user.ChangePassword("13sa09ha");

        // Assert
        user.Password.Should().Be("13sa09ha");
    }

    [Fact]
    public void ChangePassword_Should_Throw_NotImplementedException_When_NewPassword_WasNull()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();

        // Act
        Action act = () => user.ChangePassword("");

        // Assert
        act.Should().ThrowExactly<NotImplementedException>();
    }

    [Fact]
    public void SetAvatar_Should_SetAvatar()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();

        // Act
        user.SetAvatar("newPic.png");

        // Assert
        user.AvatarName.Should().Be("newPic.png");
    }

    [Fact]
    public void SetAvatar_Should_Throw_NotImplementedException_When_Avatar_WasNull()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();

        // Act
        Action act = () => user.SetAvatar("");

        // Assert
        act.Should().ThrowExactly<NotImplementedException>();
    }

    [Fact]
    public void AddAddress_Should_AddAddress()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();
        var userAddresss = _userAddressBuilder.CreatedFullUserAddress();

        // Act
        user.AddAddress(userAddresss);

        // Assert
        userAddresss.UserId.Should().Be(user.Id);
        user.Addresses.Should().HaveCount(1);
    }

    [Fact]
    public void RemoveAddress_Should_RemoveAddress()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();
        var userAddresss = _userAddressBuilder.CreatedFullUserAddress();
        var userDomainService = Substitute.For<IUserDomainService>();
        userDomainService.IsUserAddressExist(Arg.Any<long>()).Returns(true);

        // Act
        user.AddAddress(userAddresss);
        user.RemoveAddress(userAddresss.Id, userDomainService);

        // Assert
        user.Addresses.Should().HaveCount(0);
    }


    [Fact]
    public void RemoveAddress_Should_Throw_InvalidDomainDataException_When_Address_WasNot_Found()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();
        var userDomainService = Substitute.For<IUserDomainService>();
        userDomainService.IsUserAddressExist(Arg.Any<long>()).Returns(false);

        // Act
        Action act = () => user.RemoveAddress(1, userDomainService);

        // Assert
        act.Should().ThrowExactly<InvalidDomainDataException>();
    }

    [Fact]
    public void EditAddress_Should_EditAddress()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();
        var userAddress = _userAddressBuilder.CreatedFullUserAddress();
        var userAddresssEdited = _userAddressBuilder.EditFullUserAddress();
        var userDomainService = Substitute.For<IUserDomainService>();
        userDomainService.IsUserAddressExist(Arg.Any<long>()).Returns(true);

        // Act
        user.AddAddress(userAddress);
        user.EditAddress(userAddresssEdited, userAddresssEdited.Id, userDomainService);

        // Assert
        _userAddressBuilder.AssertFullForEditUserAddress(userAddresssEdited);
    }

    [Fact]
    public void EditAddress_Should_Throw_InvalidDomainDataException_When_AddressWasNotFound()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();
        var userAddress = _userAddressBuilder.CreatedFullUserAddress();
        var NullUserAddress = _userAddressBuilder.EditFullUserAddress();
        var userDomainService = Substitute.For<IUserDomainService>();
        userDomainService.IsUserAddressExist(Arg.Any<long>()).Returns(false);

        long nonExistentUserId = 12345;
        userAddress.Id = nonExistentUserId; // بعد از ادد شدن یوزر ایدی به این ایدی داده میشه

        // Act
        Action act = () => user.EditAddress(NullUserAddress, nonExistentUserId, userDomainService);

        // Assert
        act.Should().ThrowExactly<InvalidDomainDataException>();
    }

    [Fact]
    public void SetActiveAddress()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();
        var userAddress = _userAddressBuilder.CreatedFullUserAddress();

        // Act
        user.AddAddress(userAddress);
        user.SetActiveAddress(userAddress.Id);

        // Assert
        user.IsActive.Should().Be(true);
    }


    [Fact]
    public void SetActiveAddress_Throw_InvalidDomainDataException_When_AddressWasNotFound()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();

        // Act
        Action act = () => user.SetActiveAddress(1);

        // Assert
        act.Should().ThrowExactly<InvalidDomainDataException>();
    }

    [Fact]
    public void ChargeWallet_Should_ChargeWallet()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();
        var userWallet = _walletBuilder.CreateWalletWithdrawal();

        // Act
        user.ChargeWallet(userWallet);

        // Assert
        userWallet.UserId.Should().Be(user.Id);
        user.Wallets.Should().HaveCount(1);
    }

    [Fact]
    public void SetRoles_Should_SetRolesForUser()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();
        var roles = new List<UserRole>()
        {
            new UserRole(10),
            new UserRole(20),
        };

        // Act
        user.SetRoles(roles);

        // Assert
        user.Roles.Should().BeEquivalentTo(roles);
    }

    [Fact]
    public void Guard_Should_Throw_InvalidDomainDataException_When_InvalidEmail()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();
        var Email = "invalid-email";
        var userDomainService = Substitute.For<IUserDomainService>();

        // Act
        Action act = () => user.Guard(user.PhoneNumber, Email, userDomainService);

        // Assert
        act.Should().Throw<InvalidDomainDataException>();
    }
}