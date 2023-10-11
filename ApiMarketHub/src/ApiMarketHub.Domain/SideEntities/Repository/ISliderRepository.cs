using Shared.Domain.Repository;

namespace ApiMarketHub.Domain.SideEntities.Repository;
public interface ISliderRepository : IBaseRepository<Slider>
{
    void Delete(Slider slider);
}