using ApiMarketHub.Application.Roles.Create;
using ApiMarketHub.Application.Roles.Edit;
using ApiMarketHub.Query.Roles.DTO;
using ApiMarketHub.Query.Roles.GetById;
using ApiMarketHub.Query.Roles.GetList;
using MediatR;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Roles;
internal class RoleFacade : IRoleFacade
{
    private readonly IMediator _mediator;
    public RoleFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(CreateRoleCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditRoleCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<RoleDto?> GetRoleById(long RoleId)
    {
        return await _mediator.Send(new GetRoleByIdQuery(RoleId));
    }

    public async Task<List<RoleDto>> GetRoles()
    {
        return await _mediator.Send(new GetRoleListQuery());
    }
}