using ApiMarketHub.Domain.RoleAggregate;
using ApiMarketHub.Query.Roles.DTO;

namespace ApiMarketHub.Query.Roles;
public static class RoleMapper
{
    public static RoleDto Map(this Role role)
    {
        if (role == null)
            throw new ArgumentNullException();

        return new RoleDto()
        {
            Id = role.Id,
            CreationDate = role.CreationDate,
            Permissions = role.Permissions.Select(s => s.Permission).ToList(),
            Title = role.Title
        };
    }
}