using Shared.Domain.Bases;

namespace ApiMarketHub.Domain.OrderAggregate;
public class OrderAddress : BaseEntity
{
    public OrderAddress(string state, string city, string postalCode, string addressDetail, string phoneNumber, string name, string family, string nationalCode)
    {
        State = state;
        City = city;
        PostalCode = postalCode;
        AddressDetail = addressDetail;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
    }

    public long OrderId { get; internal set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string AddressDetail { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string NationalCode { get; private set; }
}