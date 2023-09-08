using ApiMarketHub.Domain.RoleAggregate.Enum;
using Shared.Domain.Bases;

namespace ApiMarketHub.Domain.RoleAggregate;
public class RolePermission : BaseEntity
{
    public RolePermission(Permission permission)
    {
        Permission = permission;
    }

    public long RoleId { get; internal set; }
    public Permission Permission { get; private set; }
}