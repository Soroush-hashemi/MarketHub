using ApiMarketHub.Domain.UserAggregate.Repository;
using ApiMarketHub.Domain.UserAggregate.Service;
using Shared.Application;

namespace ApiMarketHub.Application.Users.DeleteAddress;
public class DeleteAddressUserCommandHandler : IBaseCommandHandler<DeleteAddressUserCommand>
{
    private readonly IUserRepository _repository;
    private readonly IUserDomainService _domainService;
    public DeleteAddressUserCommandHandler(IUserRepository repository, IUserDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(DeleteAddressUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        user.RemoveAddress(request.AddressId, _domainService);
        await _repository.Save();
        return OperationResult.Success();
    }
}
