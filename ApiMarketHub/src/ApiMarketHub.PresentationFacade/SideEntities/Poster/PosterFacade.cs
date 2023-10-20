using ApiMarketHub.Application.SideEntities.Posters.Create;
using ApiMarketHub.Application.SideEntities.Posters.Delete;
using ApiMarketHub.Application.SideEntities.Posters.Edit;
using ApiMarketHub.Query.SideEntities.DTOs;
using ApiMarketHub.Query.SideEntities.Poster.GetById;
using ApiMarketHub.Query.SideEntities.Poster.GetList;
using MediatR;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.SideEntities.Poster;
internal class PosterFacade : IPosterFacade
{
    private readonly IMediator _mediator;
    public PosterFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(CreatePosterCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Delete(DeletePosterCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditPosterCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<PosterDto?> GetPosterById(long Id)
    {
        return await _mediator.Send(new GetPosterByIdQuery(Id));
    }

    public async Task<List<PosterDto>> GetPosterList()
    {
        return await _mediator.Send(new GetPosterListQuery());
    }
}