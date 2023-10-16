using ApiMarketHub.Query.SideEntities.DTOs;
using Shared.Query;

namespace ApiMarketHub.Query.SideEntities.ShippingMethods.GetById;
public record GetShippingMethodByIdQuery(long Id) : IQuery<ShippingMethodDto?>;