using Shared.Application;

namespace ApiMarketHub.Application.SideEntities.ShippingMethods.Edit;
public class EditShippingMethodCommand : IBaseCommand
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int Cost { get; set; }
}