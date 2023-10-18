using ApiMarketHub.Query.Sellers.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Sellers.Inventories.GetById;
public record GetInventoryByIdQuery(long Id) : IQuery<InventoryDto?>;