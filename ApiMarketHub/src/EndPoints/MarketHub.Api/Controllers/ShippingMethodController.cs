using ApiMarketHub.Application.SideEntities.ShippingMethods.Create;
using ApiMarketHub.Application.SideEntities.ShippingMethods.Delete;
using ApiMarketHub.Application.SideEntities.ShippingMethods.Edit;
using ApiMarketHub.PresentationFacade.SideEntities.ShippingMethods;
using ApiMarketHub.Query.SideEntities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Shared.ApiResponse;

namespace MarketHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShippingMethodController : ApiController
{
    private readonly IShippingMethodFacade _shippingMethodFacade;
    public ShippingMethodController(IShippingMethodFacade shippingMethodFacade)
    {
        _shippingMethodFacade = shippingMethodFacade;
    }

    [HttpPost]
    public async Task<ApiResult> Create(CreateShippingMethodCommand command)
    {
        var result = await _shippingMethodFacade.Create(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> Edit(EditShippingMethodCommand command)
    {
        var result = await _shippingMethodFacade.Edit(command);
        return CommandResult(result);
    }

    [HttpDelete]
    public async Task<ApiResult> Delete(DeleteShippingMethodCommand command)
    {
        var result = await _shippingMethodFacade.Delete(command);
        return CommandResult(result);
    }

    [HttpGet("{Id}")]
    public async Task<ApiResult<ShippingMethodDto?>> GetShippingMethodById(long Id)
    {
        var result = await _shippingMethodFacade.GetShippingMethodById(Id);
        return QueryResult(result);
    }

    [HttpGet]
    public async Task<ApiResult<List<ShippingMethodDto>>> GetShippingMethodDtoList()
    {
        var result = await _shippingMethodFacade.GetShippingMethodDtoList();
        return QueryResult(result);
    }
}