using Shared.Domain.Bases;
using Shared.Domain.Exceptions;
using Shared.Domain.Tools;
using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Domain.UserAggregate;
public class UserAddress : BaseEntity
{
    private UserAddress()
    {

    }

    public long UserId { get; internal set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string AddressDetail { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string NationalCode { get; private set; }
    public bool ActiveAddress { get; private set; }

    public UserAddress(string state, string city, string postalCode, string addressDetail, PhoneNumber phoneNumber, string name, string family, string nationalCode)
    {
        Guard(state, city, postalCode, addressDetail, phoneNumber, name, family, nationalCode);
        State = state;
        City = city;
        PostalCode = postalCode;
        AddressDetail = addressDetail;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
        ActiveAddress = false;
    }

    public void Edit(string state, string city, string postalCode, string addressDetail, PhoneNumber phoneNumber, string name, string family, string nationalCode)
    {
        Guard(state, city, postalCode, addressDetail, phoneNumber, name, family, nationalCode);

        State = state;
        City = city;
        PostalCode = postalCode;
        AddressDetail = addressDetail;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
    }

    public void SetActive()
    {
        ActiveAddress = true;
    }

    public void SetDeActive()
    {
        ActiveAddress = false;
    }

    public void Guard(string state, string city, string postalCode, string addressDetail, PhoneNumber phoneNumber, string name, string family, string nationalCode)
    {
        if (phoneNumber == null)
            throw new NullOrEmptyException();

        NullOrEmptyException.CheckString(state, nameof(state));
        NullOrEmptyException.CheckString(city, nameof(city));
        NullOrEmptyException.CheckString(postalCode, nameof(postalCode));
        NullOrEmptyException.CheckString(addressDetail, nameof(addressDetail));
        NullOrEmptyException.CheckString(name, nameof(name));
        NullOrEmptyException.CheckString(family, nameof(family));
        NullOrEmptyException.CheckString(nationalCode, nameof(nationalCode));

        if (IranianNationalIdChecker.IsValid(nationalCode) == false)
            throw new InvalidDomainDataException("nationalCode is invalid");
    }
}