using ApiMarketHub.Domain.RoleAggregate.Enum;

namespace ApiMarketHub.Domain.RoleAggregate;
public class RolePermission
{
    public RolePermission(Permission permission)
    {
        Permission = permission;
    }

    public long RoleId { get; internal set; }
    public Permission Permission { get; private set; }
}