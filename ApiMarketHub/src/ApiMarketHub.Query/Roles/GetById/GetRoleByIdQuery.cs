using ApiMarketHub.Query.Roles.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Roles.GetById;
public record GetRoleByIdQuery(long RoleId) : IQuery<RoleDto?>;