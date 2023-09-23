using Microsoft.AspNetCore.Http;
using Shared.Application;

namespace ApiMarketHub.Application.SideEntities.Sliders.Create;
public class CreateSliderCommand : IBaseCommand
{
    public string Title { get; set; }
    public string Link { get; set; }
    public IFormFile ImageFile { get; set; }
}