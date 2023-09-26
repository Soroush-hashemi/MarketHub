
using ApiMarketHub.Domain.UserAggregate;
using ApiMarketHub.Domain.UserAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Users.AddAddress;
public class AddAddressUserCommandHandler : IBaseCommandHandler<AddAddressUserCommand>
{
    private readonly IUserRepository _repository;

    public AddAddressUserCommandHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(AddAddressUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetTracking(request.UserId);
        if (user == null)
            return OperationResult.NotFound();

        var address = new UserAddress(request.State, request.City, request.PostalCode,
            request.AddressDetail, request.PhoneNumber, request.Name, request.Family, request.NationalCode);

        user.AddAddress(address);
        await _repository.Save();
        return OperationResult.Success();
    }
}