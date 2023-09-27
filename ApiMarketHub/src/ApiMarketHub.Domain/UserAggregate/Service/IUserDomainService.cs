using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Domain.UserAggregate.Service;
public interface IUserDomainService
{
    bool IsPhoneNumberExist(PhoneNumber phoneNumber);
}