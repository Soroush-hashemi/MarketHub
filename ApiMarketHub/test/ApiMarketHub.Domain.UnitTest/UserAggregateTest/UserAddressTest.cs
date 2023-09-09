using ApiMarketHub.Domain.UnitTest.UserAggregateTest.Builder;
using FluentAssertions;
using Shared.Domain.Exceptions;
using Xunit;

namespace ApiMarketHub.Domain.UnitTest.UserAggregateTest;
public class UserAddressTest
{
    private readonly UserAddressBuilder _userAddressBuilder;

    public UserAddressTest()
    {
        _userAddressBuilder = new UserAddressBuilder();
    }

    [Fact]
    public void Constructor_Should_Create_New_UserAddress()
    {
        // Arrange & Act
        var userAddress = _userAddressBuilder.CreatedFullUserAddress();

        // Assert
        _userAddressBuilder.AssertFullForCreateUserAddress(userAddress);
    }

    [Fact]
    public void Constructor_Should_Throw_NotImplementedException_When_Data_ExceptPhoneNumber_Was_Null()
    {
        // Arrange & Act
        Action act = () => _userAddressBuilder.CreatedNullUserAddress();

        // Assert
        act.Should().Throw<NotImplementedException>();
    }

    [Fact]
    public void Edit_Should_Edit_UserAddress()
    {
        // Arrange
        var userAddress = _userAddressBuilder.CreatedFullUserAddress();

        // Act
        userAddress = _userAddressBuilder.EditFullUserAddress();

        // Assert
        _userAddressBuilder.AssertFullForEditUserAddress(userAddress);
    }

    [Fact]
    public void SetActive_Should_Set_ActiveAddress_True()
    {
        // Arrange
        var userAddress = _userAddressBuilder.CreatedFullUserAddress();

        // Act
        userAddress.SetActive();

        // Assert
        userAddress.ActiveAddress.Should().BeTrue();
    }

    [Fact]
    public void SetDeActive_Should_Set_ActiveAddress_False()
    {
        // Arrange
        var userAddress = _userAddressBuilder.CreatedFullUserAddress();

        // Act
        userAddress.SetDeActive();

        // Assert
        userAddress.ActiveAddress.Should().BeFalse();
    }

    [Fact]
    public void Guard_Should_Throw_InvalidDomainDataException_When_PhoneNumber_Was_Null()
    {
        // Arrange & Act
        Action act = () => _userAddressBuilder.CreatedUserAddressExceptPhoneNumber();

        // Assert
        act.Should().Throw<InvalidDomainDataException>();
    }

    [Fact]
    public void Guard_Should_Throw_InvalidDomainDataException_When_NationalCode_Was_Null()
    {
        // Arrange & Act
        Action act = () => _userAddressBuilder.CreatedUserAddressExceptNationalCode();

        // Assert
        act.Should().Throw<InvalidDomainDataException>();
    }


}