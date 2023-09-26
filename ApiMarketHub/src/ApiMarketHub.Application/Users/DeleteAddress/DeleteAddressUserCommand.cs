using Shared.Application;

namespace ApiMarketHub.Application.Users.DeleteAddress;
public record DeleteAddressUserCommand(long UserId , long AddressId) : IBaseCommand;