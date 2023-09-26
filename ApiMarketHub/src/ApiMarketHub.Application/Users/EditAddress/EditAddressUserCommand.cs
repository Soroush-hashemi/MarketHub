using Shared.Application;
using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Application.Users.EditAddress;
public class EditAddressUserCommand : IBaseCommand
{
    public long UserId { get; private set; }
    public long AddressId { get; set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string AddressDetail { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string NationalCode { get; private set; }

    public EditAddressUserCommand(long userId, long addressId, string state, string city, string postalCode,
    string addressDetail, PhoneNumber phoneNumber, string name, string family, string nationalCode)
    {
        UserId = userId;
        AddressId = addressId;
        State = state;
        City = city;
        PostalCode = postalCode;
        AddressDetail = addressDetail;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
    }
}