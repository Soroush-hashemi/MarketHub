using ApiMarketHub.Domain.UserAggregate.Enums;
using Shared.Domain.ValueObjects;
using Shared.Query.Bases;

namespace ApiMarketHub.Query.Users.DTOs;
public class UserFilterData : BaseDto
{
    public string Name { get; set; }
    public string Family { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string AvatarName { get; set; }
    public Gender Gender { get; set; }
}