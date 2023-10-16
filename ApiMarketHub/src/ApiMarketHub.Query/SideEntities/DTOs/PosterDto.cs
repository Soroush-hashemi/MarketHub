using ApiMarketHub.Domain.SideEntities.Enum;
using Shared.Query.Bases;

namespace ApiMarketHub.Query.SideEntities.DTOs;
public class PosterDto : BaseDto
{
    public string Link { get; set; }
    public string ImageName { get; set; }
    public PosterPosition Position { get; set; }
}