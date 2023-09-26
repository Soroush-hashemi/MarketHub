using ApiMarketHub.Domain.UserAggregate.Enums;
using ApiMarketHub.Domain.UserAggregate.Service;
using Shared.Domain.Bases;
using Shared.Domain.Exceptions;
using Shared.Domain.Tools;
using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Domain.UserAggregate;
public class User : AggregateRoot
{

    // این قسمت از کد فقط اجازه ی تغییرات رو میده و تغییرات انجام نمیشه تا زمانی که داحل ریپازیتوری تغییرات انجام بشه
    // تقریبا تمام کد ما اینطوریه 
    // پراپرتی ها موقتا تغییر میکنن و میریم به ریپازیتوری
    private User()
    {

    }

    public string Name { get; private set; }
    public string Family { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string AvatarName { get; set; }
    public bool IsActive { get; set; }
    public Gender Gender { get; private set; }
    public List<UserRole> Roles { get; }
    public List<Wallet> Wallets { get; }
    public List<UserAddress> Addresses { get; }
    public List<UserToken> Tokens { get; }

    public User(string name, string family, PhoneNumber phoneNumber, string email, string password, Gender gender, IUserDomainService userDomainService)
    {
        Guard(phoneNumber, email, userDomainService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        Gender = gender;

        IsActive = true;
        Roles = new();
        Wallets = new();
        Addresses = new();
        Tokens = new();
    }

    public void Edit(string name, string family, PhoneNumber phoneNumber,
        string email, Gender gender, IUserDomainService userDomainService)
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

    public static User RegisterUser(PhoneNumber phoneNumber, string password, IUserDomainService userDomainService)
    {
        return new User("", "", phoneNumber, null, password, Gender.NONE, userDomainService);
    }

    public void SetAvatar(string avatarImage)
    {
        NullOrEmptyException.CheckString(avatarImage, nameof(avatarImage));
        AvatarName = avatarImage;
    }

    public void AddAddress(UserAddress address)
    {
        address.UserId = Id;
        Addresses.Add(address);
    }

    public void RemoveAddress(long AddressId, IUserDomainService userDomainService)
    {
        var previousAddress = Addresses.FirstOrDefault(a => a.Id == AddressId);
        if (userDomainService.IsUserAddressExist(AddressId) == false)
            throw new InvalidDomainDataException("Address not found");
        Addresses.Remove(previousAddress);
    }

    public void EditAddress(UserAddress address, long AddressId, IUserDomainService userDomainService)
    {
        var previousAddress = Addresses.FirstOrDefault(a => a.Id == AddressId);
        if (userDomainService.IsUserAddressExist(AddressId) == false)
            throw new InvalidDomainDataException("Address not found");

        // از ادرس قدیمی استفاده میکنیم چون جنسش از آدرسه و نیاز نیست یه وار جدید بسازیم 
        previousAddress.Edit(address.State, address.City, address.PostalCode,
      address.AddressDetail, address.PhoneNumber, address.Name, address.Family, address.NationalCode);
    }

    public void SetActiveAddress(long AddressId)
    {
        var currentAddress = Addresses.FirstOrDefault(a => a.Id == AddressId);
        if (currentAddress == null)
            throw new InvalidDomainDataException("Address not found");

        foreach (var address in Addresses)
        {
            address.SetDeActive();
        }

        currentAddress.SetActive();
    }

    public void ChargeWallet(Wallet wallet)
    {
        wallet.UserId = Id;
        Wallets.Add(wallet);
    }

    public void SetRoles(List<UserRole> roles)
    {
        roles.ForEach(f => f.UserId = Id);
        Roles.Clear();
        Roles.AddRange(roles);
    }

    public void Guard(PhoneNumber phoneNumber, string email, IUserDomainService userDomainService)
    {
        if (phoneNumber.Value.Length != 11)
            if (userDomainService.IsPhoneNumberExist(phoneNumber))
                throw new InvalidDomainDataException("PhoneNumber Is Invalid");

        if (!string.IsNullOrWhiteSpace(email))
            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException("Email Is Invalid");
    }
}