using ApiMarketHub.Domain.RoleAggregate;
using ApiMarketHub.Domain.RoleAggregate.Enum;
using Shared.Application;

namespace ApiMarketHub.Application.Roles.Create;
public class CreateRoleCommand : IBaseCommand
{
    public long userId { get; set; }
    public string Title { get; private set; }
    public List<Permission> Permissions { get; private set; }
}