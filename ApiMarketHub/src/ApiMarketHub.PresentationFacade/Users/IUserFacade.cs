using ApiMarketHub.Application.Users.Create;
using ApiMarketHub.Application.Users.Edit;
using ApiMarketHub.Query.Users.DTOs;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Users;
public interface IUserFacade
{
    Task<OperationResult> EditUser(EditUserCommand command);
    Task<OperationResult> CreateUser(CreateUserCommand command);

    Task<UserDto?> GetUserByPhoneNumber(string phoneNumber);
    Task<UserDto?> GetUserById(long userId);
    Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams);
}