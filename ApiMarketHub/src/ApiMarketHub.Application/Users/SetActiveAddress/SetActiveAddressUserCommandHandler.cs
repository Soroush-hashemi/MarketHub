using ApiMarketHub.Domain.UserAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Users.SetActiveAddress;
public class SetActiveAddressUserCommandHandler : IBaseCommandHandler<SetActiveAddressUserCommand>
{
    private readonly IUserRepository _repository;
    public SetActiveAddressUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(SetActiveAddressUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        user.SetActiveAddress(request.AddressId);

        await _repository.Save();
        return OperationResult.Success();
    }
}