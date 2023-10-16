using ApiMarketHub.Query.Sellers.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Sellers.Inventories.GetByProductId;
public record GetInventoriesByProductIdQuery(long ProductId) : IQuery<List<InventoryDto>>;