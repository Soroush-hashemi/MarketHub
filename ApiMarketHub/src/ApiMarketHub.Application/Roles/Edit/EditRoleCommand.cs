using ApiMarketHub.Domain.RoleAggregate.Enum;
using Shared.Application;
using System;

namespace ApiMarketHub.Application.Roles.Edit;
public class EditRoleCommand : IBaseCommand
{
    public long roleId { get; set; }
    public string Title { get; private set; }
    public List<Permission> Permissions { get; private set; }
}