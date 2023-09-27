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
    public void RemoveAddress_Should_RemoveAddress_When_IsUserAddressExist_Service_IsFalse()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();
        var userAddresss = _userAddressBuilder.CreatedFullUserAddress();
        var userDomainService = Substitute.For<IUserDomainService>();

        // Act
        user.AddAddress(userAddresss);
        user.RemoveAddress(userAddresss.Id);

        // Assert
        user.Addresses.Should().HaveCount(0);
    }


    [Fact]
    public void RemoveAddress_Should_Throw_InvalidDomainDataException_When_Address_WasNot_Found()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();

        // Act
        Action act = () => user.RemoveAddress(1);

        // Assert
        act.Should().ThrowExactly<InvalidDomainDataException>();
    }

    [Fact]
    public void EditAddress_Should_EditAddress_When_IsUserAddressExist_Service_IsFalse()
    {
        // Arrange
        var user = _userBuilder.Constructor_User();
        var userAddress = _userAddressBuilder.CreatedFullUserAddress();
        var userAddresssEdited = _userAddressBuilder.EditFullUserAddress();

        // Act
        user.AddAddress(userAddress);
        user.EditAddress(userAddresssEdited, userAddresssEdited.Id);

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

        long nonExistentUserId = 12345;
        userAddress.Id = nonExistentUserId; // بعد از ادد شدن یوزر ایدی به این ایدی داده میشه

        // Act
        Action act = () => user.EditAddress(NullUserAddress, nonExistentUserId);

        // Assert
        act.Should().ThrowExactly<InvalidDomainDataException>();
    }

    [Fact]
    public void SetActiveAddress_When_currentAddress_IsNot_Null()
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