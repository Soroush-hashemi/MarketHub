using ApiMarketHub.Domain.SideEntities;

namespace ApiMarketHub.Domain.UnitTest.SideEntities.Builder;
public class SliderBuilder
{
    public Slider CreateSlider()
    {
        var slider = new Slider("DiscountProduct", "https://localhost:7165/product/p1", "productImage.png", true);
        return slider;
    }
}