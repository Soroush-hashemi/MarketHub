using ApiMarketHub.Domain.RoleAggregate.Enum;
using Shared.Application;

namespace ApiMarketHub.Application.Roles.Create;
public record CreateRoleCommand(string Title, List<Permission> Permissions) : IBaseCommand;