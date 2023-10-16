using ApiMarketHub.Query.Sellers.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Sellers.Inventories.GetList;
public record GetInventoriesQuery(long Id) : IQuery<List<InventoryDto>>;