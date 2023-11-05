using ApiMarketHub.Application.Sellers.AddInventory;
using ApiMarketHub.Application.Sellers.Create;
using ApiMarketHub.Application.Sellers.Edit;
using ApiMarketHub.Application.Sellers.EditInventory;
using ApiMarketHub.PresentationFacade.Sellers;
using ApiMarketHub.PresentationFacade.Sellers.Inventories;
using ApiMarketHub.Query.Sellers.DTOs;
using Microsoft.AspNetCore.Mvc;
using Shared.ApiResponse;

namespace MarketHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SellerController : ApiController
{
    private readonly ISellerFacade _sellerFacade;
    private readonly ISellerInventoryFacade _sellerInventoryFacade;
    public SellerController(ISellerFacade sellerFacade, ISellerInventoryFacade sellerInventoryFacade)
    {
        _sellerFacade = sellerFacade;
        _sellerInventoryFacade = sellerInventoryFacade;
    }

    // Seller

    [HttpPost]
    public async Task<ApiResult> Create(CreateSellerCommand command)
    {
        var result = await _sellerFacade.Create(command);
        return CommandResult(result);
    }

    [HttpPut]
    public async Task<ApiResult> Edit(EditSellerCommand command)
    {
        var result = await _sellerFacade.Edit(command);
        return CommandResult(result);
    }

    [HttpGet("{Id}")]
    public async Task<ApiResult<SellerDto?>> GetSellerById(long Id)
    {
        var result = await _sellerFacade.GetSellerById(Id);
        return QueryResult(result);
    }

    [HttpGet("GetByUserId")]
    public async Task<ApiResult<SellerDto?>> GetSellerByUserId()
    {
        var result = await _sellerFacade.GetSellerByUserId(User.GetUserId());
        return QueryResult(result);
    }

    [HttpGet("Filter")]
    public async Task<ApiResult<SellerFilterResult>> GetSellersByFilter(SellerFilterParams filterParams)
    {
        var result = await _sellerFacade.GetSellersByFilter(filterParams);
        return QueryResult(result);
    }

    //  SellerInventory

    [HttpPost("Inventory")]
    public async Task<ApiResult> AddInventory(AddSellerInventoryCommand command)
    {
        var result = await _sellerInventoryFacade.AddInventory(command);
        return CommandResult(result);
    }

    [HttpPut("Inventory")]
    public async Task<ApiResult> EditInventory(EditSellerInventoryCommand command)
    {
        var result = await _sellerInventoryFacade.EditInventory(command);
        return CommandResult(result);
    }

    [HttpGet("Inventory/{inventoryId}")]
    public async Task<ApiResult<InventoryDto?>> GetById(long InventoryId)
    {
        var result = await _sellerInventoryFacade.GetById(InventoryId);
        return QueryResult(result);
    }

    [HttpGet("Inventory")]
    public async Task<ApiResult<List<InventoryDto>>> GetList()
    {
        var seller = await _sellerFacade.GetSellerByUserId(User.GetUserId());
        if (seller == null)
            throw new NullReferenceException();

        var result = await _sellerInventoryFacade.GetList(seller.Id);
        return QueryResult(result);
    }

    [HttpGet("Inventory/{productId}")]
    public async Task<ApiResult<List<InventoryDto>>> GetByProductId(long productId)
    {
        var result = await _sellerInventoryFacade.GetList(productId);
        return QueryResult(result);
    }
}