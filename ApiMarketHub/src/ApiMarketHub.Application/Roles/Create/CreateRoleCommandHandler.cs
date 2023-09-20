using ApiMarketHub.Domain.RoleAggregate;
using ApiMarketHub.Domain.RoleAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Roles.Create;
public class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
{
    private readonly IRoleRepository _roleRepository;
    public CreateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var permissions = new List<RolePermission>();
        request.Permissions.ForEach(p =>
        {
            permissions.Add(new RolePermission(p));
        });

        var role = new Role(request.Title, permissions);

        _roleRepository.Add(role);
        await _roleRepository.Save();
        return OperationResult.Success();
    }
}