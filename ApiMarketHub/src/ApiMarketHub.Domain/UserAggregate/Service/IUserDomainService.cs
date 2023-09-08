using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Domain.UserAggregate.Service;
public interface IUserDomainService
{
    bool IsEmailExist(string email);
    bool IsPhoneNumberExist(PhoneNumber phoneNumber);
}