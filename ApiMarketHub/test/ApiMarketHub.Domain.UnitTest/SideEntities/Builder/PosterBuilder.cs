using ApiMarketHub.Domain.SideEntities;
using ApiMarketHub.Domain.SideEntities.Enum;

namespace ApiMarketHub.Domain.UnitTest.SideEntities.Builder;
public class PosterBuilder
{
    public Poster CreateFullPoster()
    {
        var link = "https://localhost:7165/product";
        var imageName = "productnum123.png";

        var poster = new Poster(link, imageName, PosterPosition.above_slider);
        return poster;
    }
}