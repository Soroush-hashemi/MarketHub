using ApiMarketHub.Domain.SideEntities.Enum;
using Microsoft.AspNetCore.Http;
using Shared.Application;

namespace ApiMarketHub.Application.SideEntities.Posters.Edit;
public class EditPosterCommand : IBaseCommand
{
    public long PosterId { get; set; }
    public string Link { get; set; }
    public IFormFile? ImageFile { get; set; }
    public PosterPosition Position { get; set; }
}