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
}