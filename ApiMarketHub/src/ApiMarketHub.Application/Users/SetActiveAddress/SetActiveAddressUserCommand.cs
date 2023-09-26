using Shared.Application;

namespace ApiMarketHub.Application.Users.SetActiveAddress;
public record SetActiveAddressUserCommand(long UserId, long AddressId) : IBaseCommand;