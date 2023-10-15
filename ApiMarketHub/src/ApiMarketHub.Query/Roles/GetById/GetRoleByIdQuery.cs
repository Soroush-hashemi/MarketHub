using ApiMarketHub.Query.Roles.DTO;
using Shared.Query;

namespace ApiMarketHub.Query.Roles.GetById;
public record GetRoleByIdQuery(long RoleId) : IQuery<RoleDto?>;