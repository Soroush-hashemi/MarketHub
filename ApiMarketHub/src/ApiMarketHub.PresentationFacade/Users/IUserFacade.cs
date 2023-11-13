using ApiMarketHub.Application.Users.Create;
using ApiMarketHub.Application.Users.Edit;
using ApiMarketHub.Query.Users.DTOs;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Users;
public interface IUserFacade
{
    Task<OperationResult> Create(CreateUserCommand command);
    Task<OperationResult> Edit(EditUserCommand command);

    Task<UserDto?> GetUserByPhoneNumber(string phoneNumber);
    Task<UserDto?> GetUserById(long userId);
    Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams);
}