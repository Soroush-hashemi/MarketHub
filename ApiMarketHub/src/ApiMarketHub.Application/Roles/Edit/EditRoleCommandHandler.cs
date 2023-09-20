using ApiMarketHub.Domain.RoleAggregate;
using ApiMarketHub.Domain.RoleAggregate.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.Roles.Edit;
public class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
{
    private readonly IRoleRepository _roleRepository;
    public EditRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetTracking(request.roleId);
        if (role == null)
            return OperationResult.NotFound();

        role.Edit(request.Title);
        var permissions = new List<RolePermission>();
        request.Permissions.ForEach(p =>
        {
            permissions.Add(new RolePermission(p));
        }); // تمام دسترسی هارو دونه دونه به لیست اضافه میکنه

        role.SetPermissions(permissions);
        await _roleRepository.Save();
        return OperationResult.Success();
    }
}