using Shared.Application;

namespace ApiMarketHub.Application.SideEntities.ShippingMethods.Delete;
public class DeleteShippingMethodCommand : IBaseCommand
{
    public long Id { get; set; }
}