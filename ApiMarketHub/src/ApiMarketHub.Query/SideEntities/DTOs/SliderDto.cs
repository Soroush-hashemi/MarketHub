using Shared.Query.Bases;

namespace ApiMarketHub.Query.SideEntities.DTOs;
public class SliderDto : BaseDto
{
    public string Title { get; set; }
    public string Link { get; set; }
    public string ImageName { get; set; }
}