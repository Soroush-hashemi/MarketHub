using ApiMarketHub.Application.Users.AddAddress;
using ApiMarketHub.Application.Users.DeleteAddress;
using ApiMarketHub.Application.Users.EditAddress;
using ApiMarketHub.Application.Users.SetActiveAddress;
using ApiMarketHub.Query.Users.DTOs;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Users.Addresses;
public interface IUserAddressFacade
{
    Task<OperationResult> AddAddress(AddAddressUserCommand command);
    Task<OperationResult> EditAddress(EditAddressUserCommand command);
    Task<OperationResult> DeleteAddress(DeleteAddressUserCommand command);
    Task<OperationResult> SetActiveAddress(SetActiveAddressUserCommand command);

    Task<AddressDto?> GetById(long userAddressId);
    Task<List<AddressDto>> GetList(long userId);
}