using ApiMarketHub.Application.SideEntities.Posters.Create;
using ApiMarketHub.Application.SideEntities.Posters.Delete;
using ApiMarketHub.Application.SideEntities.Posters.Edit;
using ApiMarketHub.Query.SideEntities.DTOs;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.SideEntities.Poster;
public interface IPosterFacade
{
    Task<OperationResult> Create(CreatePosterCommand command);
    Task<OperationResult> Delete(DeletePosterCommand command);
    Task<OperationResult> Edit(EditPosterCommand command);

    Task<PosterDto?> GetPosterById(long Id);
    Task<List<PosterDto>> GetPosterList();
}