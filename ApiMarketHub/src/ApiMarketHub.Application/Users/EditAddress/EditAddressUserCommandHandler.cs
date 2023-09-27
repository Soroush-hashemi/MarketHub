using ApiMarketHub.Domain.UserAggregate;
using ApiMarketHub.Domain.UserAggregate.Repository;
using ApiMarketHub.Domain.UserAggregate.Service;
using Shared.Application;

namespace ApiMarketHub.Application.Users.EditAddress;
public class EditAddressUserCommandHandler : IBaseCommandHandler<EditAddressUserCommand>
{
    private readonly IUserRepository _repository;
    public EditAddressUserCommandHandler(IUserRepository repository, IUserDomainService domainService)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditAddressUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        var address = new UserAddress(request.State, request.City, request.PostalCode,
            request.AddressDetail, request.PhoneNumber, request.Name, request.Family, request.NationalCode);

        user.EditAddress(address, request.AddressId);

        await _repository.Save();
        return OperationResult.Success();
    }
}