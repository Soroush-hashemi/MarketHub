using ApiMarketHub.Domain.UserAggregate;
using ApiMarketHub.Domain.UserAggregate.Repository;
using ApiMarketHub.Domain.UserAggregate.Service;
using Shared.Application;
using Shared.Application.FileUtil.Interfaces;
using Shared.Application.SecurityUtil;

namespace ApiMarketHub.Application.Users.Create;
public class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserDomainService _userDomainService;
    private readonly IFileService _fileService;
    public CreateUserCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService)
    {
        _userRepository = userRepository;
        _userDomainService = userDomainService;
    }

    public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var password = Sha256Hasher.Hash(request.Password);
        var user = new User(request.Name, request.Family, request.PhoneNumber, request.Email, password, request.Gender, _userDomainService);

        _userRepository.Add(user);
        await _userRepository.Save();
        return OperationResult.Success();
    }
}
