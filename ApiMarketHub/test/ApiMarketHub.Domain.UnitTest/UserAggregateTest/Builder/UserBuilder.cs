using ApiMarketHub.Domain.UserAggregate;
using ApiMarketHub.Domain.UserAggregate.Enums;
using ApiMarketHub.Domain.UserAggregate.Service;
using FluentAssertions;
using NSubstitute;
using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Domain.UnitTest.UserAggregateTest.Builder;
public class UserBuilder
{
    public User Constructor_User()
    {
        var userDomainService = Substitute.For<IUserDomainService>();

        string name = "soroush";
        string family = "hashemi";
        PhoneNumber phoneNumber = new PhoneNumber("09901112233");
        string email = "soroush@gmail.com";
        string password = "1w2e3r4t!?";
        Gender gender = Gender.MALE;
        string avatarName = "soroush.png";

        var user = new User(name, family, phoneNumber, email, password, avatarName, gender, userDomainService);
        return user;
    }

    public void AssertForConstructorFull_User(User user)
    {
        user.Name.Should().Be("soroush");
        user.Family.Should().Be("hashemi");
        user.PhoneNumber.Value.Should().Be("09901112233");
        user.Email.Should().Be("soroush@gmail.com");
        user.Password.Should().Be("1w2e3r4t!?");
        user.Gender.Should().Be(Gender.MALE);
        user.AvatarName.Should().Be("soroush.png");
    }

    public void AssertForEdit(User user)
    {
        user.Name.Should().Be("soroush2");
        user.Family.Should().Be("hashemi2");
        user.PhoneNumber.Value.Should().Be("09902224455");
        user.Email.Should().Be("soroush8@gmail.com");
        user.Gender.Should().Be(Gender.NONE);
    }
}