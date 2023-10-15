using ApiMarketHub.Domain.RoleAggregate.Enum;
using Shared.Query.Bases;

namespace ApiMarketHub.Query.Roles.DTO;
public class RoleDto : BaseDto
{
    public string Title { get; set; }
    public List<Permission> Permissions { get; set; }
}