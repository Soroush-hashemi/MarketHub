using Shared.Application;

namespace ApiMarketHub.Application.SideEntities.ShippingMethods.Create;
public class CreateShippingMethodCommand : IBaseCommand
{
    public string Title { get; set; }
    public int Cost { get; set; }
}