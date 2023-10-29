using ApiMarketHub.Application.Roles.Create;
using ApiMarketHub.Application.Roles.Edit;
using ApiMarketHub.PresentationFacade.Roles;
using ApiMarketHub.Query.Roles.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ApiResponse;

namespace MarketHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ApiController
    {
        private readonly IRoleFacade _roleFacade;

        public RoleController(IRoleFacade roleFacade)
        {
            _roleFacade = roleFacade;
        }

        [HttpPost]
        public async Task<ApiResult> CreateRole(CreateRoleCommand command)
        {
            var result = await _roleFacade.Create(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditRole(EditRoleCommand command)
        {
            var result = await _roleFacade.Edit(command);
            return CommandResult(result);
        }
        [HttpGet]
        public async Task<ApiResult<List<RoleDto>>> GetRoles()
        {
            var result = await _roleFacade.GetRoles();
            return QueryResult(result);
        }

        [HttpGet("{roleId}")]
        public async Task<ApiResult<RoleDto?>> GetRoleById(long roleId)
        {
            var result = await _roleFacade.GetRoleById(roleId);
            return QueryResult(result);
        }
    }
}
