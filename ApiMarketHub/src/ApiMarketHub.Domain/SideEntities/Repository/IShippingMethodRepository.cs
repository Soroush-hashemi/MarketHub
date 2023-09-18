using Common.Domain.Repository;

namespace ApiMarketHub.Domain.SideEntities.Repository;
public interface IShippingMethodRepository : IBaseRepository<ShippingMethod>
{
    void Delete(ShippingMethod method);
}