using ApiMarketHub.Application.Roles.Create;
using ApiMarketHub.Application.Roles.Edit;
using ApiMarketHub.Query.Roles.DTO;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Roles;
public interface IRoleFacade
{
    Task<OperationResult> Create(CreateRoleCommand command);
    Task<OperationResult> Edit(EditRoleCommand command);

    Task<RoleDto?> GetRoleById(long RoleId);
    Task<List<RoleDto>> GetRoles();
}