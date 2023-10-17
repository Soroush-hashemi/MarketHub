using ApiMarketHub.Domain.UserAggregate.Enums;
using Shared.Domain.ValueObjects;
using Shared.Query.Bases;

namespace ApiMarketHub.Query.Users.DTOs;
public class UserDto : BaseDto
{
    public string Name { get; set; }
    public string Family { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string AvatarName { get; set; }
    public bool IsActive { get; set; }
    public Gender Gender { get; set; }
    public List<UserRoleDto> Roles { get; set; }
}

public class UserRoleDto
{
    public long RoleId { get; set; }
    public string RoleTitle { get; set; }
}