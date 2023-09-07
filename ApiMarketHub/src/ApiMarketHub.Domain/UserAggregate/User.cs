using ApiMarketHub.Domain.UserAggregate.Enums;
using ApiMarketHub.Domain.UserAggregate.Services;
using Shared.Domain.Bases;
using Shared.Domain.Exception;
using Shared.Domain.Tools;

namespace ApiMarketHub.Domain.UserAggregate;
public class User : AggregateRoot
{
    private User()
    {

    }

    public string Name { get; private set; }
    public string Family { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string AvatarName { get; set; }
    public bool IsActive { get; set; }
    public Gender Gender { get; private set; }
    public List<UserRole> Roles { get; }
    public List<Wallet> Wallets { get; }
    public List<UserAddress> Addresses { get; }
    public List<UserToken> Tokens { get; }


    public User(string name, string family, string phoneNumber, string email, string password, Gender gender, IUserDomainService userDomainService)
    {
        Guard(phoneNumber, email, userDomainService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        Gender = gender;
        AvatarName = "avatar.png";
        IsActive = true;
        Roles = new();
        Wallets = new();
        Addresses = new();
        Tokens = new();
    }

    public void Edit(string name, string family, string phoneNumber, string email, Gender gender, IUserDomainService userDomainService)
    {
        Guard(phoneNumber, email, userDomainService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Gender = gender;
    }

    public void ChangePassword(string newPassword)
    {
        NullOrEmptyException.CheckString(newPassword, nameof(newPassword));
        Password = newPassword;
    }
    public static User RegisterUser(string phoneNumber, string password, IUserDomainService userDomainService)
    {
        return new User("", "", phoneNumber, null, password, Gender.NONE, userDomainService);
    }


    public void Guard(string phoneNumber, string email, IUserDomainService userDomainService)
    {
        NullOrEmptyException.CheckString(phoneNumber, nameof(phoneNumber));

        if (phoneNumber.Length != 11)
            throw new ("شماره موبایل نامعتبر است");

        if (!string.IsNullOrWhiteSpace(email))
            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException(" ایمیل  نامعتبر است");

        if (phoneNumber != PhoneNumber)
            if (userDomainService.IsPhoneNumberExist(phoneNumber))
                throw new InvalidDomainDataException("شماره موبایل تکراری است");

        if (email != Email)
            if (userDomainService.IsEmailExist(email))
                throw new InvalidDomainDataException("ایمیل تکراری است");
    }
}