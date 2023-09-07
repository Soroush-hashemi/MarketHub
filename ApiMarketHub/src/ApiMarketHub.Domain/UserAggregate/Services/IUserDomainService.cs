namespace ApiMarketHub.Domain.UserAggregate.Services;
internal interface IUserDomainService
{
    bool IsEmailExist(string email);
    bool IsPhoneNumberExist(string phoneNumber);
}