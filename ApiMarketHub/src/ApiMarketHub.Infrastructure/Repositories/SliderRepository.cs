using ApiMarketHub.Domain.SideEntities;
using ApiMarketHub.Domain.SideEntities.Repository;
using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Repositories.Base;

namespace ApiMarketHub.Infrastructure.Repositories;
public class SliderRepository : BaseRepository<Slider>, ISliderRepository
{
    public SliderRepository(Context context) : base(context)
    {
    }

    public void Delete(Slider slider)
    {
        _context.Sliders.Remove(slider);
    }
}