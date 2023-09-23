using Microsoft.AspNetCore.Http;
using Shared.Application;

namespace ApiMarketHub.Application.SideEntities.Sliders.Edit;
public class EditSliderCommand : IBaseCommand
{
    public long SilderId { get; set; }
    public string Title { get; set; }
    public string Link { get; set; }
    public IFormFile? ImageFile { get; set; }
}