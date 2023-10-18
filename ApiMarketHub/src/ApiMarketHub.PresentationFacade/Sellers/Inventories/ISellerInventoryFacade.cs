using ApiMarketHub.Application.Sellers.AddInventory;
using ApiMarketHub.Application.Sellers.EditInventory;
using ApiMarketHub.Query.Sellers.DTOs;
using Shared.Application;

namespace ApiMarketHub.PresentationFacade.Sellers.Inventories;
public interface ISellerInventoryFacade
{
    Task<OperationResult> AddInventory(AddSellerInventoryCommand command);
    Task<OperationResult> EditInventory(EditSellerInventoryCommand command);

    Task<InventoryDto?> GetById(long inventoryId);
    Task<List<InventoryDto>> GetList(long sellerId);
    Task<List<InventoryDto>> GetByProductId(long productId);
}