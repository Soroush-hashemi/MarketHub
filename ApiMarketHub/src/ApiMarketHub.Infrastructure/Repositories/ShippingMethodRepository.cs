using ApiMarketHub.Domain.SideEntities;
using ApiMarketHub.Domain.SideEntities.Repository;
using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Repositories.Base;

namespace ApiMarketHub.Infrastructure.Repositories;
public class ShippingMethodRepository : BaseRepository<ShippingMethod>, IShippingMethodRepository
{
    public ShippingMethodRepository(MarketHubContext context) : base(context)
    {
    }

    public void Delete(ShippingMethod method)
    {
        _context.ShippingMethods.Remove(method);
    }
}