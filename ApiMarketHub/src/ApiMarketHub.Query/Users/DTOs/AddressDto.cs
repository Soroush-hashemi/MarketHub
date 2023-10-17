using Shared.Domain.ValueObjects;
using Shared.Query.Bases;

namespace ApiMarketHub.Query.Users.DTOs;
public class AddressDto : BaseDto
{
    public long UserId { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string AddressDetail { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string NationalCode { get; set; }
    public bool ActiveAddress { get; set; }
}