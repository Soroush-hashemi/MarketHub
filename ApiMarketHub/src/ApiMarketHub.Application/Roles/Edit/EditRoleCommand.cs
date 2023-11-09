using ApiMarketHub.Domain.RoleAggregate.Enum;
using Shared.Application;
using System;

namespace ApiMarketHub.Application.Roles.Edit;
public record EditRoleCommand(long roleId, string Title, List<Permission> Permissions) : IBaseCommand;