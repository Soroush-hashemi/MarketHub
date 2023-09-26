using ApiMarketHub.Domain.UserAggregate.Enums;
using Microsoft.AspNetCore.Http;
using Shared.Application;
using Shared.Application.FileUtil.Interfaces;
using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Application.Users.Edit;
public class EditUserCommand : IBaseCommand
{
    public long UserId { get; set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public Gender Gender { get; private set; }
    public IFormFile? Avatar { get; private set; }

    public EditUserCommand(long userId, string name, string family, PhoneNumber phoneNumber, string email, IFormFile? avatar, Gender gender)
    {
        UserId = userId;
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Avatar = avatar;
        Gender = gender;
    }
}