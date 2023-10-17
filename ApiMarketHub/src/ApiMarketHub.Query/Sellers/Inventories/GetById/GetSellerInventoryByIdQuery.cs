using ApiMarketHub.Query.Sellers.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.Sellers.Inventories.GetById;
public record GetSellerInventoryByIdQuery(long Id) : IQuery<InventoryDto?>;