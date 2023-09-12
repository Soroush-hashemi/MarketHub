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