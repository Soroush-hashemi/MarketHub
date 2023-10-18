using ApiMarketHub.Application.SideEntities.Sliders.Create;
using ApiMarketHub.Application.SideEntities.Sliders.Delete;
using ApiMarketHub.Application.SideEntities.Sliders.Edit;
using ApiMarketHub.Query.SideEntities.DTOs;
using ApiMarketHub.Query.SideEntities.Sliders.GetById;
using ApiMarketHub.Query.SideEntities.Sliders.GetList;
using MediatR;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.SideEntities.Slider;
internal class SliderFacade : ISliderFacade
{
    private readonly Mediator _mediator;
    public SliderFacade(Mediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(CreateSliderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Delete(DeleteSliderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditSliderCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<SliderDto?> GetSliderById(long Id)
    {
        return await _mediator.Send(new GetSliderByIdQuery(Id));
    }

    public async Task<List<SliderDto>> GetSliderListQuery()
    {
        return await _mediator.Send(new GetSliderListQuery());
    }
}