using ApiMarketHub.Domain.UserAggregate;
using FluentAssertions;
using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Domain.UnitTest.UserAggregateTest.Builder;
public class UserAddressBuilder
{
    public UserAddress CreatedFullUserAddress()
    {
        string state = "kurdistan";
        string city = "CenterKurdistan";
        string postalCode = "1234567890";
        string addressDetail = "kochay bala dar qrimiz";
        string name = "soroush";
        string family = "hash";
        string nationalCode = "9794140023";

        var userAddress = new UserAddress(state, city, postalCode, addressDetail,
            new PhoneNumber("09210001122"), name, family, nationalCode);

        return userAddress;
    }

    public UserAddress EditFullUserAddress()
    {
        string state = "kermanshah";
        string city = "kermanshah";
        string postalCode = "2224567890";
        string addressDetail = "st.n 2";
        string name = "Soroush2";
        string family = "hashemi";
        string nationalCode = "4544065968";

        var userAddress = new UserAddress(state, city, postalCode, addressDetail,
            new PhoneNumber("09210003322"), name, family, nationalCode);

        return userAddress;
    }

    public UserAddress CreatedUserAddressExceptPhoneNumber()
    {
        string state = "kurdistan";
        string city = "CenterKurdistan";
        string postalCode = "1234567890";
        string addressDetail = "kochay bala dar qrimiz";
        string name = "soroush";
        string family = "hash";
        string nationalCode = "9794140023";

        var userAddress = new UserAddress(state, city, postalCode, addressDetail,
            new PhoneNumber(""), name, family, nationalCode);

        return userAddress;
    }

    public UserAddress CreatedUserAddressExceptNationalCode()
    {
        string state = "kurdistan";
        string city = "CenterKurdistan";
        string postalCode = "1234567890";
        string addressDetail = "kochay bala dar qrimiz";
        string name = "soroush";
        string family = "hash";
        string nationalCode = "";

        var userAddress = new UserAddress(state, city, postalCode, addressDetail,
            new PhoneNumber(""), name, family, nationalCode);

        return userAddress;
    }

    public void AssertFullForEditUserAddress(UserAddress userAddress)
    {
        userAddress.State.Should().Be("kermanshah");
        userAddress.City.Should().Be("kermanshah");
        userAddress.PostalCode.Should().Be("2224567890");
        userAddress.AddressDetail.Should().Be("st.n 2");
        userAddress.Name.Should().Be("Soroush2");
        userAddress.Family.Should().Be("hashemi");
        userAddress.NationalCode.Should().Be("4544065968");
        userAddress.PhoneNumber.Value.Should().Be("09210003322");
    }
}