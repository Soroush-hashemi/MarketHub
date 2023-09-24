using ApiMarketHub.Application.SideEntities.ShippingMethods.Edit;
using ApiMarketHub.Domain.SideEntities.Repository;
using Shared.Application;

namespace ApiMarketHub.Application.SideEntities.ShippingMethods.Delete;
public class DeleteShippingMethodCommand : IBaseCommand
{
    public long Id { get; set; }
}