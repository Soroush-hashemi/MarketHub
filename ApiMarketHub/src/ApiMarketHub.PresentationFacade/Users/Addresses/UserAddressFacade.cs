using ApiMarketHub.Application.Users.AddAddress;
using ApiMarketHub.Application.Users.DeleteAddress;
using ApiMarketHub.Application.Users.EditAddress;
using ApiMarketHub.Application.Users.SetActiveAddress;
using ApiMarketHub.Query.Users.Addresses.GetById;
using ApiMarketHub.Query.Users.Addresses.GetList;
using ApiMarketHub.Query.Users.DTOs;
using MediatR;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Users.Addresses;
internal class UserAddressFacade : IUserAddressFacade
{
    private readonly IMediator _mediator;

    public UserAddressFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddAddress(AddAddressUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> DeleteAddress(DeleteAddressUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditAddress(EditAddressUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> SetActiveAddress(SetActiveAddressUserCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<AddressDto?> GetAddressById(long userAddressId)
    {
        return await _mediator.Send(new GetUserAddressByIdQuery(userAddressId));
    }

    public async Task<List<AddressDto>> GetAddressList(long userId)
    {
        return await _mediator.Send(new GetUserAddressesListQuery(userId));
    }
}