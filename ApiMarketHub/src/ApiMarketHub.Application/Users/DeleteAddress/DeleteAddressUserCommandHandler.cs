using ApiMarketHub.Domain.UserAggregate.Repository;
using ApiMarketHub.Domain.UserAggregate.Service;
using Shared.Application;

namespace ApiMarketHub.Application.Users.DeleteAddress;
public class DeleteAddressUserCommandHandler : IBaseCommandHandler<DeleteAddressUserCommand>
{
    private readonly IUserRepository _repository;
    public DeleteAddressUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(DeleteAddressUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        user.RemoveAddress(request.AddressId);

        await _repository.Save();
        return OperationResult.Success();
    }
}
