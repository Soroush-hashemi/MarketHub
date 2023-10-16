using Shared.Query.Bases;

namespace ApiMarketHub.Query.SideEntities.DTOs;
public class ShippingMethodDto : BaseDto
{
    public string Title { get; set; }
    public int Cost { get; set; }
}