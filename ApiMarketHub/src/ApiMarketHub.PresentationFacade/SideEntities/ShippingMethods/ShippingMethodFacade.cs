using ApiMarketHub.Application.SideEntities.ShippingMethods.Create;
using ApiMarketHub.Application.SideEntities.ShippingMethods.Delete;
using ApiMarketHub.Application.SideEntities.ShippingMethods.Edit;
using ApiMarketHub.Query.SideEntities.DTOs;
using ApiMarketHub.Query.SideEntities.ShippingMethods.GetById;
using ApiMarketHub.Query.SideEntities.ShippingMethods.GetList;
using MediatR;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.SideEntities.ShippingMethods;
internal class ShippingMethodFacade : IShippingMethodFacade
{
    private readonly Mediator _mediator;
    public ShippingMethodFacade(Mediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(CreateShippingMethodCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Delete(DeleteShippingMethodCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditShippingMethodCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<ShippingMethodDto?> GetShippingMethodById(long Id)
    {
        return await _mediator.Send(new GetShippingMethodByIdQuery(Id));
    }

    public async Task<List<ShippingMethodDto>> GetShippingMethodDtoList()
    {
        return await _mediator.Send(new GetShippingMethodsByListQuery());
    }
}