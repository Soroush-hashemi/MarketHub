using ApiMarketHub.Application.Users.AddAddress;
using ApiMarketHub.Application.Users.Create;
using ApiMarketHub.Application.Users.DeleteAddress;
using ApiMarketHub.Application.Users.Edit;
using ApiMarketHub.Application.Users.EditAddress;
using ApiMarketHub.Application.Users.SetActiveAddress;
using ApiMarketHub.PresentationFacade.Users;
using ApiMarketHub.PresentationFacade.Users.Addresses;
using ApiMarketHub.Query.Users.DTOs;
using Microsoft.AspNetCore.Mvc;
using Shared.ApiResponse;

namespace MarketHub.Api.Controllers;

public class UserController : ApiController
{
    private readonly IUserFacade _userFacade;
    private readonly IUserAddressFacade _userAddressFacade;
    public UserController(IUserFacade userFacade, IUserAddressFacade userAddressFacade)
    {
        _userFacade = userFacade;
        _userAddressFacade = userAddressFacade;
    }

    [HttpPost]
    public async Task<ApiResult> Create(CreateUserCommand command)
    {
        var result = await _userFacade.Create(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> Edit(EditUserCommand command)
    {
        var result = await _userFacade.Edit(command);
        return CommandResult(result);
    }

    [HttpGet("{phoneNumber}")]
    public async Task<ApiResult<UserDto?>> GetUserByPhoneNumber(string phoneNumber)
    {
        var result = await _userFacade.GetUserByPhoneNumber(phoneNumber);
        return QueryResult(result);
    }

    [HttpGet("{userId}")]
    public async Task<ApiResult<UserDto?>> GetUserById(long userId)
    {
        var result = await _userFacade.GetUserById(userId);
        return QueryResult(result);
    }

    [HttpGet("filter")]
    public async Task<ApiResult<UserFilterResult>> GetUserByFilter(UserFilterParams filterParams)
    {
        var result = await _userFacade.GetUserByFilter(filterParams);
        return QueryResult(result);
    }

    // UserAddress

    [HttpPost("Address/Add")]
    public async Task<ApiResult> AddAddress(AddAddressUserCommand command)
    {
        var result = await _userAddressFacade.AddAddress(command);
        return CommandResult(result);
    }

    [HttpPut("Address/Edit")]
    public async Task<ApiResult> EditAddress(EditAddressUserCommand command)
    {
        var result = await _userAddressFacade.EditAddress(command);
        return CommandResult(result);
    }

    [HttpDelete("Address/Delete")]
    public async Task<ApiResult> DeleteAddress(DeleteAddressUserCommand command)
    {
        var result = await _userAddressFacade.DeleteAddress(command);
        return CommandResult(result);
    }

    [HttpPut("Address/SetActive")]
    public async Task<ApiResult> SetActiveAddress(SetActiveAddressUserCommand command)
    {
        var result = await _userAddressFacade.SetActiveAddress(command);
        return CommandResult(result);
    }

    [HttpGet("Address/{userAddressId}")]
    public async Task<ApiResult<AddressDto?>> GetAddressById(long userAddressId)
    {
        var result = await _userAddressFacade.GetAddressById(userAddressId);
        return QueryResult(result);
    }

    [HttpGet("Address/GetList")]
    public async Task<ApiResult<List<AddressDto>>> GetAddressList(long userId)
    {
        var result = await _userAddressFacade.GetAddressList(userId);
        return QueryResult(result);
    }
}