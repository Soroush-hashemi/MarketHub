using ApiMarketHub.Domain.UserAggregate.Repository;
using ApiMarketHub.Domain.UserAggregate.Service;
using Shared.Domain.ValueObjects;

namespace ApiMarketHub.Application.Users;
public class UserDomainService : IUserDomainService
{
    private readonly IUserRepository _repository;
    public UserDomainService(IUserRepository repository)
    {
        _repository = repository;
    }

    public bool IsPhoneNumberExist(PhoneNumber phoneNumber)
    {
        var PhoneExist = _repository.Exists(p => p.PhoneNumber == phoneNumber); // میشه true اگر در سیستم موحود باشه مقدار متغییر ما 
        return !PhoneExist; // پس باید برعکسش کنیم ! و برگشتش بدیم
    }
}