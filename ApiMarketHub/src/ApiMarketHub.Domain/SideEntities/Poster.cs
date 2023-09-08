using ApiMarketHub.Domain.SideEntities.Enum;
using Shared.Domain.Bases;
using Shared.Domain.Exceptions;

namespace ApiMarketHub.Domain.SideEntities;
public class Poster : BaseEntity
{
    public string Link { get; private set; }
    public string ImageName { get; private set; }
    public PosterPosition Position { get; set; }

    public Poster(string link, string imageName, PosterPosition position)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        Position = position;
    }

    public void Edit(string link, string imageName, PosterPosition position)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        Position = position;
    }

    public void Guard(string link, string imageName)
    {
        NullOrEmptyException.CheckString(link, nameof(link));
        NullOrEmptyException.CheckString(imageName, nameof(imageName));
    }
}