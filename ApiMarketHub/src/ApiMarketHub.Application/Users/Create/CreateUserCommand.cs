using ApiMarketHub.Domain.UserAggregate.Enums;
using Microsoft.AspNetCore.Http;
using Shared.Application;
using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Application.Users.Create;
public class CreateUserCommand : IBaseCommand
{
    public string Name { get; private set; }
    public string Family { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Gender Gender { get; private set; }

    public CreateUserCommand(string name, string family, PhoneNumber phoneNumber, string email, string password, Gender gender)
    {
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        Gender = gender;
    }
}