using ApiMarketHub.Application.Sellers.AddInventory;
using ApiMarketHub.Application.Sellers.EditInventory;
using ApiMarketHub.Domain.ProductAggregate;
using ApiMarketHub.Query.Sellers.DTOs;
using ApiMarketHub.Query.Sellers.Inventories.GetById;
using ApiMarketHub.Query.Sellers.Inventories.GetByProductId;
using ApiMarketHub.Query.Sellers.Inventories.GetList;
using MediatR;
using Shared.Application;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiMarketHub.PresentationFacade.Sellers.Inventories;
internal class SellerInventoryFacade : ISellerInventoryFacade
{
    private readonly IMediator _mediator;
    public SellerInventoryFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> AddInventory(AddSellerInventoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> EditInventory(EditSellerInventoryCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<InventoryDto?> GetById(long inventoryId)
    {
        return await _mediator.Send(new GetInventoryByIdQuery(inventoryId));
    }

    public async Task<List<InventoryDto>> GetByProductId(long productId)
    {
        return await _mediator.Send(new GetInventoriesByProductIdQuery(productId));
    }

    public async Task<List<InventoryDto>> GetList(long sellerId)
    {
        return await _mediator.Send(new GetInventoriesQuery(sellerId));
    }
}