

using Shared.Domain.Exceptions;

namespace ApiMarketHub.Domain.RoleAggregate;
public class Role
{
    public string Title { get; private set; }
    public List<RolePermission> Permissions { get; private set; }

    private Role()
    {

    }

    public Role(string title, List<RolePermission> permissions)
    {
        NullOrEmptyException.CheckString(title, nameof(title));

        Title = title;
        Permissions = permissions;
    }

    public Role(string title)
    {
        NullOrEmptyException.CheckString(title, nameof(title));

        Title = title;
    }

    public void Edit(string title)
    {
        NullOrEmptyException.CheckString(title, nameof(title));
        Title = title;
    }

    public void SetPermissions(List<RolePermission> permissions)
    {
        Permissions = permissions;
    }
}