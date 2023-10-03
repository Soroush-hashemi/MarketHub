using ApiMarketHub.Domain.SellerAggregate;
using ApiMarketHub.Domain.SellerAggregate.Repository;
using ApiMarketHub.Infrastructure.Persistence.Command;
using ApiMarketHub.Infrastructure.Repositories.Base;

namespace ApiMarketHub.Infrastructure.Repositories;
public class SellerRepository : BaseRepository<Seller>, ISellerRepository
{
    public SellerRepository(Context context) : base(context)
    {
    }

    public Task<InventoryInfo?> GetInventoryById(long id)
    {
        throw new NotImplementedException();
    }
}
