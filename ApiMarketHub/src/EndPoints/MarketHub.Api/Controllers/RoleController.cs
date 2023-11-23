using ApiMarketHub.Application.Roles.Create;
using ApiMarketHub.Application.Roles.Edit;
using ApiMarketHub.PresentationFacade.Roles;
using ApiMarketHub.Query.Roles.DTO;
using Microsoft.AspNetCore.Mvc;
using Shared.ApiResponse;

namespace MarketHub.Api.Controllers;
public class RoleController : ApiController
{
    private readonly IRoleFacade _roleFacade;

    public RoleController(IRoleFacade roleFacade)
    {
        _roleFacade = roleFacade;
    }

    [HttpPost]
    public async Task<ApiResult> Create(CreateRoleCommand command)
    {
        var result = await _roleFacade.Create(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> Edit(EditRoleCommand command)
    {
        var result = await _roleFacade.Edit(command);
        return CommandResult(result);
    }

    [HttpGet("{SId}")]
    public async Task<ApiResult<RoleDto?>> GetRoleById(long Id)
    {
        var result = await _roleFacade.GetRoleById(Id);
        return QueryResult(result);
    }

    [HttpGet]
    public async Task<ApiResult<List<RoleDto>>> GetRoles()
    {
        var result = await _roleFacade.GetRoles();
        return QueryResult(result);
    }
}