using ApiMarketHub.Application.Roles.Create;
using ApiMarketHub.Application.Roles.Edit;
using ApiMarketHub.Application.SideEntities.Posters.Create;
using ApiMarketHub.Application.SideEntities.Posters.Delete;
using ApiMarketHub.Application.SideEntities.Posters.Edit;
using ApiMarketHub.PresentationFacade.Roles;
using ApiMarketHub.PresentationFacade.SideEntities.Poster;
using ApiMarketHub.Query.Roles.DTO;
using ApiMarketHub.Query.SideEntities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Shared.ApiResponse;

namespace MarketHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PosterController : ApiController
{
    private readonly IPosterFacade _posterFacade;
    public PosterController(IPosterFacade posterFacade)
    {
        _posterFacade = posterFacade;
    }

    [HttpPost]
    public async Task<ApiResult> Create(CreatePosterCommand command)
    {
        var result = await _posterFacade.Create(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> Edit(EditPosterCommand command)
    {
        var result = await _posterFacade.Edit(command);
        return CommandResult(result);
    }

    [HttpDelete]
    public async Task<ApiResult> Delete(DeletePosterCommand command)
    {
        var result = await _posterFacade.Delete(command);
        return CommandResult(result);
    }

    [HttpGet("{Id}")]
    public async Task<ApiResult<PosterDto?>> GetPosterById(long Id)
    {
        var result = await _posterFacade.GetPosterById(Id);
        return QueryResult(result);
    }

    [HttpGet]
    public async Task<ApiResult<List<PosterDto>>> GetPosterList()
    {
        var result = await _posterFacade.GetPosterList();
        return QueryResult(result);
    }
}